using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Autodesk.AutoCAD.DatabaseServices;
using Autodesk.AutoCAD.EditorInput;

namespace GCad
{
    namespace Machines
    {
        [Serializable]
        internal struct MachineData
        {
            public string name;
            public string author;
            public string description;
            public List<KeyValuePair<string, string>> attributes;
        }

        public abstract class Machine
        {
            internal MachineData data;
            internal abstract ObjectIdCollection Select(GCodeConfig config);
            internal abstract string Process(ObjectIdCollection objects, GCodeConfig config);
        }
    }
}
