using System;
using System.Linq.Expressions;
using Autodesk.AutoCAD.DatabaseServices;
using Autodesk.AutoCAD.EditorInput;
using Autodesk.AutoCAD.Geometry;
using System.Runtime.CompilerServices;
using Autodesk.AutoCAD.ApplicationServices;
using System.Security.Policy;

namespace GCad
{
    internal sealed class Utils
    {
        public static ObjectIdCollection SelectAroundPoint(Point3d point, GCodeConfig config)
        {
            Init(out Editor editor);
            try
            {

                Point3d p1 = new Point3d(point.X - config.Tolerance, point.Y - config.Tolerance, 0.0);
                Point3d p2 = new Point3d(point.X + config.Tolerance, point.Y + config.Tolerance, 0.0);


                PromptSelectionResult result = editor.SelectCrossingWindow(p1, p2, new SelectionFilter(config.Filter));
                if (result.Value != null)
                {
                    return new ObjectIdCollection(result.Value.GetObjectIds());
                }

            }
            catch (NullReferenceException) { }
            return new ObjectIdCollection();
        }

        public static void Explode(ObjectId id, ref ObjectIdCollection idsToModify)
        {
            Utils.Init(out Database database);
            try
            {
                using Transaction explodeTransaction = database.TransactionManager.StartTransaction();
                DBObjectCollection objects = new DBObjectCollection();
                ObjectIdCollection ids = new ObjectIdCollection();
                Entity explodedObject = (Entity)explodeTransaction.GetObject(id,
                                                                             OpenMode.ForRead);

                explodedObject.Explode(objects);

                explodedObject.UpgradeOpen();
                explodedObject.Erase();

                BlockTableRecord btr = (BlockTableRecord)explodeTransaction.GetObject(
                    Autodesk.AutoCAD.ApplicationServices.Core.Application.DocumentManager.MdiActiveDocument.Database.CurrentSpaceId,
                    OpenMode.ForWrite);
                foreach (DBObject @object in objects)
                {
                    Entity addedObject = (Entity)@object;
                    btr.AppendEntity(addedObject);
                    explodeTransaction.AddNewlyCreatedDBObject(addedObject, true);
                }
                explodeTransaction.Commit();
                foreach (DBObject @object in objects) idsToModify.Add(@object.Id);
                idsToModify.Remove(id);
            }
            catch (Exception) { }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void Init(out Editor editor, out Database database)
        {
            editor = Application.DocumentManager.CurrentDocument.Editor;
            database = Application.DocumentManager.CurrentDocument.Database;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void Init(out Editor editor)
        {
            editor = Application.DocumentManager.CurrentDocument.Editor;
            
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void Init(out Database database)
        {
            database = Application.DocumentManager.CurrentDocument.Database;
        }
    }
}
