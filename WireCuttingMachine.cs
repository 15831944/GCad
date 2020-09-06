using System;
using System.Collections.Generic;
using Autodesk.AutoCAD.ApplicationServices;
using Autodesk.AutoCAD.DatabaseServices;
using Autodesk.AutoCAD.EditorInput;
using Autodesk.AutoCAD.Geometry;
namespace GCad
{
    namespace Machines
    {
        [Serializable]
        internal class WireCuttingMachine : Machine
        {
            internal WireCuttingMachine()
            {
                data.name = "Wire Cutting Machine";
                data.description = "";
                data.attributes = new List<KeyValuePair<string, string>>
                {
                    new KeyValuePair<string, string>("--no-entry", "Disables entry gcode"),
                    new KeyValuePair<string, string>("--no-return", "Disables branch-return gcode. Disable only if path is an outline"),
                };
                data.author = "Albert Maftei NC";
            }

            internal override string Process(ObjectIdCollection objects, GCodeConfig config)
            {
                Utils.Init(out Editor editor);
                offset = editor.CurrentUserCoordinateSystem.Translation;
                offset = offset.Negate();
                Point3d point = editor.GetPoint("Select starting point: ").Value;
                objectIds = objects;
                foreach (ObjectId id in objectIds)
                {
                    Utils.Explode(id, ref objectIds);
                }
                using (this.transaction = Application.DocumentManager.MdiActiveDocument.Database.TransactionManager.StartTransaction())
                    return Traverse(point, config);
            }
            private Vector3d offset ;
            private ObjectIdCollection objectIds;
            private Transaction transaction;

            private string Traverse(Point3d point, GCodeConfig config)
            {
                
                string gcode = ((!config.AdditionalArguments.Contains("--no-entry")) ? $"G00 {config.Formatter.Format2D(point.Add(new Vector3d(0, 1, 0)))};\n" : "") +
                               $"G01 {config.Formatter.Format2D(point)};\n";

                foreach (ObjectId id in Utils.SelectAroundPoint(point, config))
                {

                    if (objectIds.Contains(id))
                    {
                        objectIds.Remove(id);
                        foreach (Type type in config.AvailableTypes)
                        {
                            try
                            {
                                gcode += Traverse(point, (dynamic)Convert.ChangeType(transaction.GetObject(id, OpenMode.ForRead), type), config);
                            }
                            catch (Exception) { }
                        }
                    }
                }
                gcode += (!config.AdditionalArguments.Contains("--no-return")) ? $"G01 {config.Formatter.Format2D(point)};\n" : "";
                gcode += (!config.AdditionalArguments.Contains("--no-entry")) ? $"G01 {config.Formatter.Format2D(point.Add(new Vector3d(0, 1, 0)))};\n" : "";
                return gcode;
            }

            private string Traverse(Point3d from, Line line, GCodeConfig config)
            {
                string gcode = "";
                if (from.DistanceTo(line.StartPoint.Add(offset)) <= config.Tolerance)
                {

                    gcode += $"G01 {config.Formatter.Format2D(line.EndPoint.Add(offset))};\n";


                    foreach (ObjectId id in Utils.SelectAroundPoint(line.EndPoint.Add(offset), config))
                    {
                        if (objectIds.Contains(id))
                        {
                            objectIds.Remove(id);
                            foreach (Type type in config.AvailableTypes)
                            {
                                try
                                {
                                    gcode += Traverse(line.EndPoint.Add(offset), (dynamic)Convert.ChangeType(transaction.GetObject(id, OpenMode.ForRead), type), config);
                                }
                                catch (Exception) { }
                            }
                        }
                    }

                    gcode += (!config.AdditionalArguments.Contains("--no-return")) ? $"G01 {config.Formatter.Format2D(line.StartPoint.Add(offset))};\n" : "";




                }
                else
                {
                    gcode += $"G01 {config.Formatter.Format2D(line.StartPoint.Add(offset))};\n";


                    foreach (ObjectId id in Utils.SelectAroundPoint(line.StartPoint.Add(offset), config))
                    {
                        if (objectIds.Contains(id))
                        {
                            objectIds.Remove(id);
                            foreach (Type type in config.AvailableTypes)
                            {
                                try
                                {
                                    gcode += Traverse(line.StartPoint.Add(offset), (dynamic)Convert.ChangeType(transaction.GetObject(id, OpenMode.ForRead), type), config);
                                }
                                catch (Exception) { }
                            }
                        }
                    }

                    gcode += (!config.AdditionalArguments.Contains("--no-return")) ? $"G01 {config.Formatter.Format2D(line.EndPoint.Add(offset))};\n" : "";
                }
                return gcode;

            }
            private string Traverse(Point3d from, Arc arc, GCodeConfig config)
            {
                string gcode = "";
                if (from.DistanceTo(arc.StartPoint.Add(offset)) <= config.Tolerance)
                {

                    gcode += $"G03 {config.Formatter.Format2D(arc.EndPoint.Add(offset))} "+
                        $"I{config.Formatter.Format1D(arc.StartPoint.GetVectorTo(arc.Center).X)} "+
                        $"J{config.Formatter.Format1D(arc.StartPoint.GetVectorTo(arc.Center).Y)};\n";


                    foreach (ObjectId id in Utils.SelectAroundPoint(arc.EndPoint.Add(offset), config))
                    {
                        if (objectIds.Contains(id))
                        {
                            objectIds.Remove(id);
                            foreach (Type type in config.AvailableTypes)
                            {
                                try
                                {
                                    gcode += Traverse(arc.EndPoint.Add(offset), (dynamic)Convert.ChangeType(transaction.GetObject(id, OpenMode.ForRead), type), config);
                                }
                                catch (Exception) { }
                            }
                        }
                    }

                    gcode += (!config.AdditionalArguments.Contains("--no-return")) ? $"G02 {config.Formatter.Format2D(arc.StartPoint.Add(offset))} "+
                        $"I{config.Formatter.Format1D(arc.EndPoint.GetVectorTo(arc.Center).X)} "+$"" +
                        $"J{config.Formatter.Format1D(arc.EndPoint.GetVectorTo(arc.Center).Y)};\n" : "";


                }
                else
                {
                    gcode += $"G02 {config.Formatter.Format2D(arc.StartPoint.Add(offset))} " +
                        $"I{config.Formatter.Format1D(arc.EndPoint.GetVectorTo(arc.Center).X)} "+ 
                        $"J{config.Formatter.Format1D(arc.EndPoint.GetVectorTo(arc.Center).Y)};\n";


                    foreach (ObjectId id in Utils.SelectAroundPoint(arc.StartPoint.Add(offset), config))
                    {
                        if (objectIds.Contains(id))
                        {
                            objectIds.Remove(id);
                            foreach (Type type in config.AvailableTypes)
                            {
                                try
                                {
                                    gcode += Traverse(arc.StartPoint.Add(offset), (dynamic)Convert.ChangeType(transaction.GetObject(id, OpenMode.ForRead), type), config);
                                }
                                catch (Exception) { }
                            }
                        }
                    }


                    gcode += (!config.AdditionalArguments.Contains("--no-return")) ? $"G03 {config.Formatter.Format2D(arc.EndPoint.Add(offset))} "+
                        $"I{config.Formatter.Format1D(arc.StartPoint.GetVectorTo(arc.Center.Add(offset)).X)} " + 
                        $"J{config.Formatter.Format1D(arc.StartPoint.GetVectorTo(arc.Center.Add(offset)).Y)};\n" : "";

                }
                return gcode;

            }

            internal override ObjectIdCollection Select(GCodeConfig config)
            {
                Utils.Init(out Editor editor);
                PromptSelectionResult res = editor.GetSelection(new PromptSelectionOptions() { MessageForAdding = "Select objects: " },
                    new SelectionFilter(config.Filter));

                if (!(res.Status == PromptStatus.OK))
                    return new ObjectIdCollection();

                return new ObjectIdCollection(res.Value.GetObjectIds());
            }
        }
    }
}
