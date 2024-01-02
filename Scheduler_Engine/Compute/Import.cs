/*
 * This file is part of the Buildings and Habitats object Model (BHoM)
 * Copyright (c) 2015 - 2024, the respective contributors. All rights reserved.
 *
 * Each contributor holds copyright over their respective contributions.
 * The project versioning (Git) records all such contribution source information.
 *                                           
 *                                                                              
 * The BHoM is free software: you can redistribute it and/or modify         
 * it under the terms of the GNU Lesser General Public License as published by  
 * the Free Software Foundation, either version 3.0 of the License, or          
 * (at your option) any later version.                                          
 *                                                                              
 * The BHoM is distributed in the hope that it will be useful,              
 * but WITHOUT ANY WARRANTY; without even the implied warranty of               
 * MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE. See the                 
 * GNU Lesser General Public License for more details.                          
 *                                                                            
 * You should have received a copy of the GNU Lesser General Public License     
 * along with this code. If not, see <https://www.gnu.org/licenses/lgpl-3.0.html>.      
 */

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using BH.oM.Data.Requests;
using BH.oM.Base;
using BH.Adapter.File;
//using BH.oM.Scheduler.Components;
//using BH.oM.Scheduler;
//using BH.oM.Spatial.SettingOut;
//using BH.oM.Scheduler.Enums;
using System.Diagnostics;

namespace BH.Engine.Scheduler.Compute
{
    public static partial class Import
    {
        public static IList<object> Imported = new List<object>();
        //public static Document Document = new Document();
        private static string folder = @"C:\Users\TomJames\Lightos\Lightos Hub - Documents\05-Projects\BHoM\Scheduler\";

        private static string file = @"revitFile.json";

        private static string jsonFilePath = folder + file;

        public static void WithSerialiser()
        {
            try
            {
                Stopwatch sw = new Stopwatch();

                Console.Write("Pulling the data from file...");

                if (File.Exists(jsonFilePath))
                {
                    sw.Start();
                    //foreach (string jsonFilePath in GetJsonFiles())
                    //{
                    try
                    {
                        string[] json = File.ReadAllLines(jsonFilePath);
                        Imported = json.Select(x => BH.Engine.Serialiser.Convert.FromJson(x)).ToList();
                    }
                    catch (Exception ea)
                    { var s = ea.Message; }

                    //}
                    sw.Stop();
                    Console.WriteLine("Done in " + sw.ElapsedMilliseconds + " milliseconds.");
                }
                else
                { }
            }
            catch (Exception ae)
            {
                var s = ae.Message;
                //Base.Compute.RecordError(ae.Message);
                //if (ae.InnerException != null) Base.Compute.RecordError(ae.InnerException.ToString());
            }
        }

        private static IList<string> GetJsonFiles()
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

        public static void WithAdapter()
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
