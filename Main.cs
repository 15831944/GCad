using System.IO;
using System.Windows.Forms;
using Autodesk.AutoCAD.DatabaseServices;
using Autodesk.AutoCAD.EditorInput;
using Autodesk.AutoCAD.ApplicationServices;
using Autodesk.AutoCAD.Runtime;
using System;
using Autodesk.AutoCAD.Geometry;
using GCad;
using System.Collections;
using System.Configuration;
using System.Collections.Generic;
using System.CodeDom;

namespace GCad
{
    public sealed class Main
    {

        internal GCodeConfig config = GCodeConfig.Load();

        [CommandMethod("GC")]
        public void GC()
        {
            

            if (SelectFile(out StreamWriter writer)) // Selects output file
            {
                
                writer.Write(config.Machine.Process(config.Machine.Select(config), config));
                writer.Close();
            }

        }

            [CommandMethod("GCSET")]
        public void GCSET()
        {
            Settings settings = new Settings(config);
            settings.ShowDialog();
            if(settings.Modify)
            config = settings.config;   
            GCodeConfig.Save(config);
        }

        
        private bool SelectFile(out StreamWriter writer)
        {
            var dialog = new SaveFileDialog()
            {
                Title = "Save File As",
                Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*",
                InitialDirectory = "C:\\",
            };

            if (dialog.ShowDialog() == DialogResult.OK)
            {
                writer = new StreamWriter(dialog.FileName);
                return true;
            } 
            else
            {
                writer = null;
                return false;
            }
        }
    }

    internal sealed class Constants
    {
        public static List<Machines.Machine> Machines = new List<Machines.Machine>() { new Machines.WireCuttingMachine() };
        public static Type[] AvailableTypes = new Type[] { typeof(Line), typeof(Arc) };
        public static TypedValue[] Filter = new TypedValue[] {new TypedValue((int)DxfCode.Operator, "<or"), 
            new TypedValue((int) DxfCode.Start, "LINE"),
            new TypedValue((int) DxfCode.Start, "ARC"),
            new TypedValue((int)(DxfCode.Start), "POLYLINE"),
            new TypedValue((int)(DxfCode.Start), "LWPOLYLINE"),
            new TypedValue((int)(DxfCode.Start), "POLYLINE2D"),
            new TypedValue((int)(DxfCode.Start), "POLYLINE3d"),
            new TypedValue((int) DxfCode.Operator, "or>")};
    }

    internal sealed class GCodeConfig 
    {
    

        public Machines.Machine Machine { get; set; }
        public Formatter Formatter { get; set; }
        public double Tolerance { get; set; }
        public Type[] AvailableTypes { get; set; }
        public TypedValue[] Filter { get; set; }
        public List<string> AdditionalArguments { get; set; }

        internal GCodeConfig(Machines.Machine machine, Formatter formatter, double tolerance, TypedValue[] filter, Type[] availableTypes, string[] additionalArguments)
        {
            Machine = machine;
            Formatter = formatter;
            Tolerance = tolerance;
            AvailableTypes = availableTypes;
            Filter = filter;
            AdditionalArguments = new List<string>(additionalArguments);
        }

        internal static GCodeConfig Load()
        {
            return new GCodeConfig(Constants.Machines[(Properties.Settings.Default.machineIndex == -1) ? 0 : Properties.Settings.Default.machineIndex],
                new Formatter(Properties.Settings.Default.decimals),
                Properties.Settings.Default.tolerance,
                Constants.Filter,
                Constants.AvailableTypes,
                Properties.Settings.Default.additionalArguments.Split(' '));

          
        }

        internal static void Save(GCodeConfig config)
        {
            Properties.Settings.Default.machineIndex = Constants.Machines.IndexOf(config.Machine);
            Properties.Settings.Default.decimals = config.Formatter.Decimals;
            Properties.Settings.Default.tolerance = config.Tolerance;
            Properties.Settings.Default.additionalArguments = "";
            foreach(string s in config.AdditionalArguments)
            {
                Properties.Settings.Default.additionalArguments += s + " ";
            }
            Properties.Settings.Default.additionalArguments = Properties.Settings.Default.additionalArguments.Trim();
            Properties.Settings.Default.Save();
        }
    }

}
