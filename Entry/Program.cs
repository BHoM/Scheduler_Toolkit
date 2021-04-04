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
                //LoadBHoMAssemblies();

                ///Scheduler
                //BH.Engine.Scheduler.Compute.ImportWithAdapter();
                BH.Engine.Scheduler.Compute.ImportWithSerialiser();

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
                //BH.Engine.Reflection.Compute.RecordError(ae.Message);
                //if (ae.InnerException != null) BH.Engine.Reflection.Compute.RecordError(ae.InnerException.ToString());
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
