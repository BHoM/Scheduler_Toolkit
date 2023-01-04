using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using BH.oM.Data.Requests;
using System.Diagnostics;
using BH.oM.Base;
using BH.Adapter.File;
using BH.oM.Scheduler.Components;
using BH.oM.Scheduler;
using BH.oM.Spatial.SettingOut;
using BH.oM.Scheduler.Enums;

namespace BH.Engine.Scheduler.Compute
{
    public static partial class Import
    {
        public static void WithSerialiser2()
        {
            try
            {
                Stopwatch sw = new Stopwatch();

                Console.Write("Pulling the data from file...");

                //if (File.Exists(jsonFilePath))
                //{
                sw.Start();
                foreach (string f in GetJsonFiles())
                {
                    try
                    {
                        string[] json = File.ReadAllLines(f);
                        Imported = json.Select(x => BH.Engine.Serialiser.Convert.FromJson(x)).ToList();
                    }
                    catch (Exception)
                    { }
                }
                sw.Stop();

                Console.WriteLine("Done in " + sw.ElapsedMilliseconds + " milliseconds.");
                //else
                //{ }
            }
            catch (Exception ae)
            {
                var s = ae.Message;
                //Base.Compute.RecordError(ae.Message);
                //if (ae.InnerException != null) Base.Compute.RecordError(ae.InnerException.ToString());
            }
        }

        private static IList<string> GetJsonFiles2()
        {
            IList<string> files = new List<string>()
            {
                folder + @"revitModel.json",
                folder + @"revitModel-onlyPhases.json",
                folder + @"revitModel-elementsAndLevels.json",
                folder + @"revitModel-onlyLevels.json",
                folder + @"revitModel v3.json",
                folder + @"revitModel v2.json",
                folder + @"revitModel.json"
            };

            foreach (var f in files)
            {
                if (!File.Exists(f))
                { files.Remove(f); }
            }
            return files;
        }

        public static void ImportWithAdapter2()
        {
            try
            {
                Console.Write("Pulling the data from adapter...");
                Stopwatch sw = new Stopwatch();


                FileAdapter adapter = new FileAdapter(folder, file);

                sw.Start();
                List<object> result2 = adapter.Pull(new FilterRequest()).ToList();
                sw.Stop();

                Console.WriteLine("Done in " + sw.ElapsedMilliseconds + " milliseconds.");
            }
            catch (Exception ae)
            {
                var s = ae.Message;
                //Base.Compute.RecordError(ae.Message);
                //if (ae.InnerException != null) Base.Compute.RecordError(ae.InnerException.ToString());
            }
        }

        //public static void PopulateDocument()
        //{
        //    try
        //    {
        //        Create.Document.Tasks.Add(new ElementTask()
        //        {
        //            HeadingType = HeadingType.Root,
        //            Name = "Project Base Date",
        //            PhaseType = PhaseType.None,
        //            Vendor = Vendor3DApplication.Unknown,
        //            TaskSpecificData =
        //            {
        //                new DataItem() { Name = "Duration", Value = "0", Unit = "days" },
        //                new DataItem() { Name = "Start", Value = DateTime.Now.ToString("ddd DD/MM/yy"), Unit = "" },
        //                //new DataItem() { Name = "Finish", Value = DateTime.Now.ToString("ddd DD/MM/yy"), Unit = "" }
        //            },
        //            TaskId = "1"
        //        });
        //        Create.Document.Tasks.Add(new ElementTask()
        //        {
        //            HeadingType = HeadingType.Root,
        //            Name = "Prelims (un-modelled elements)",
        //            PhaseType = PhaseType.None,
        //            Vendor = Vendor3DApplication.Unknown,
        //            TaskId = "2",
        //            ParentTask = "1"
        //        });

        //        foreach (Phase p in Create.Document.Phases.Where(e => e.Order > 0))
        //        { ByPhase(p); }
        //    }
        //    catch (Exception ae)
        //    {
        //        //BH.Engine.Base.Compute.RecordError( 
        //        Base.Compute.RecordError(ae.Message);
        //        if (ae.InnerException != null) Base.Compute.RecordError(ae.InnerException.ToString());
        //    }
        //}

        //private static void ByPhase(Phase p)
        //{
        //    try
        //    {
        //        List<object> currentPhase = Imported.Select(e => e).ToList();
        //    }
        //    catch (Exception ae)
        //    {
        //        Base.Compute.RecordError(ae.Message);
        //        if (ae.InnerException != null) Base.Compute.RecordError(ae.InnerException.ToString());
        //    }
        //}

        //private static void ByGroups(Phase p)
        //{
        //    try
        //    {

        //    }
        //    catch (Exception ae)
        //    {
        //        Base.Compute.RecordError(ae.Message);
        //        if (ae.InnerException != null) Base.Compute.RecordError(ae.InnerException.ToString());
        //    }
        //}

        //private static Level LevelCastManual(CustomObject c)
        //{
        //    Level l = new Level();
        //    try
        //    {
        //        List<string> cdToBeRemoved = new List<string>();
        //        FragmentSet fs = new FragmentSet();
        //        var ds = c.CustomData;
        //        foreach (var d in ds)
        //        {
        //            if (d.Key == "Elevation")
        //            {
        //                double o = double.NaN;
        //                double.TryParse(d.Value.ToString(), out o);
        //                if (o != double.NaN)
        //                { l.Elevation = o; }
        //                cdToBeRemoved.Add(d.Key);
        //            }
        //            else if (d.Key == "Fragments")
        //            {
        //                //List<object> o1 = (List<object>)d.Value;

        //                //for (int i = 0; i < o1.Count; i++)
        //                //{
        //                //    //fs.Add((IFragment)o1[i]);
        //                //    fs.Add(o1[i]);
        //                //}
        //                //l.Fragments = (FragmentSet)d.Value;
        //            }
        //        }

        //        cdToBeRemoved.ForEach(s => c.CustomData.Remove(s));

        //        l.BHoM_Guid = c.BHoM_Guid;
        //        l.Tags = c.Tags;
        //        l.Name = c.Name;
        //        l.Fragments = fs;
        //    }
        //    catch (Exception ae)
        //    {
        //        Base.Compute.RecordError(ae.Message);
        //        if (ae.InnerException != null) Base.Compute.RecordError(ae.InnerException.ToString());
        //    }
        //    return l;
        //}
    }
}