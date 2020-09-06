using System;
using Autodesk.AutoCAD.Geometry;
using System.Diagnostics;
namespace GCad
{
    [Serializable]
    public struct Formatter
    {
        public string Format { get; private set; }
        internal int Decimals { get; set; }

        public Formatter(int decimals)
        {
            Decimals = decimals;
            Format = "";
            UpdateFormat(decimals);
        }

        public void UpdateFormat(int decimals)
        {
            Decimals = decimals;
            Format = $"{{0:0{(decimals > 0 ? "." : "")}";
            for (int i = 0; i < decimals; i++) Format += "0";
            Format += "}";
        }
        public string Format1D(double obj)
        {
            return string.Format(Format, obj);
        }
        public string Format2D(Point2d obj)
        {
            return $"X{Format1D(obj.X)}Y{Format1D(obj.Y)}";
        }
        public string Format2D(Point3d point)
        {
            return $"X{Format1D(point.X)}Y{Format1D(point.Y)}";
        
        }
        public string Format3D(Point3d obj)
        {
            return $"X{Format1D(obj.X)} Y{Format1D(obj.Y)} Z{Format1D(obj.Z)}";
        }
    }
}
