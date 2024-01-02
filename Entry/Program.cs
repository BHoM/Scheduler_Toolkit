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
using System.Reflection;
using System.IO;
using System.Diagnostics;
using System.Threading;
using System.Collections.Generic;
using System.Linq;

namespace Entry
{
    class Program
    {
        [STAThread]
        static void Main(string[] args)
        {
            try
            {
                //Load BHoM libraries
                LoadBHoMAssemblies();

                ///Scheduler
                BH.Engine.Scheduler.Compute.Import.WithAdapter();
                //BH.Engine.Scheduler.Compute.Import.WithSerialiser();

                //if (Transfer.Levels.PhaseManualCorrection(BH.Engine.Scheduler.Compute.Imported.ToList()) == true)
                //{
                //    BH.Engine.Scheduler.Compute.PopulateDocument();
                //}

                ///ATO
                //BH.Engine.ATO.Compute.ImportWithSerialiser();
                //BH.Engine.ATO.Compute.ImportWithAdapter(); //Adaptor deserialisation fails (25-Jun-2020)

                ////Fake processing pause
                //Transfer.JSON.ImportWithDialogBox();
                //Stopwatch sw = new Stopwatch();
                //sw.Start();
                //Console.WriteLine("Processing...");
                //var spinner = new Spinner(14, 2);
                //spinner.Start();
                //Thread.Sleep(9432);
                //spinner.Stop();
                //sw.Stop();
                //Console.WriteLine("Quantities extracted in " + sw.ElapsedMilliseconds + " milliseconds.");

                //Console.ForegroundColor = ConsoleColor.White;
                //Console.WriteLine("Press ENTER to close console......");
                //string line = Console.ReadLine();
                //if (line == "enter")
                //{ Environment.Exit(0); }
            }
            catch (Exception ae)
            {
                var s = ae.Message;
                //BH.Engine.Base.Compute.RecordError(ae.Message);
                //if (ae.InnerException != null) BH.Engine.Base.Compute.RecordError(ae.InnerException.ToString());
            }
        }

        static void LoadBHoMAssemblies()
        {
            Stopwatch sw = new Stopwatch();

            Console.Write("Loading assemblies...");
            sw.Start();
            //foreach (string file in Directory.GetFiles(@"C:\ProgramData\BHoM\Assemblies"))
            foreach (string file in Directory.GetFiles(@"C:\ProgramData\BHoM\Assemblies"))
            {
                try
                {
                    Assembly.LoadFrom(file);
                }
                catch { }
            }
            sw.Stop();
            Console.WriteLine("Done in " + sw.ElapsedMilliseconds + " milliseconds.");
        }
    }
}

