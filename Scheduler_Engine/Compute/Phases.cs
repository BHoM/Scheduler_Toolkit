
using BH.oM.Scheduler.Components;
using BH.oM.Scheduler.Enums;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BH.Engine.Scheduler.Compute
{
    public static class Phases
    {
        public static Phase Existing;
        public static Phase NewConstruction;
        public static IList<Phase> lAll = new List<Phase>();
        public static bool Get()
        {
            try
            {
                lAll = Engine.Scheduler.Compute.Phases.lAll.Cast<Phase>()
                                .Where(e => e.GetType() == typeof(Phase))
                                .OrderBy(e => e.Order)
                                .ToList();

                foreach (Phase p in lAll)
                {
                    if (p.Name == "Existing")
                    {
                        Existing = p;
                    }
                    if (p.Name == "New Construction")
                    {
                        NewConstruction = p;
                    }
                }
                if (NewConstruction == null || Existing == null)
                {
                    return false;
                }
                else
                {
                    return true;
                }
            }
            catch (Exception ae)
            {
                Reflection.Compute.RecordError(ae.Message);
                if (ae.InnerException != null) Reflection.Compute.RecordError(ae.InnerException.ToString());
            }
            return false;
        }

        //TODO re-introduction PhaseType property assignment
        //public static PhaseType Type(Phase p, ElementId Created, ElementId Demolished)
        //{
        //    try
        //    {
        //        if (Phases.Get.lAll.Count(ph => ph == p) == 1)
        //        {
        //            Phase pC = Phases.Get.lAll.First(ph => ph == p);
        //            if (pC.Id == Created)
        //            {
        //                if (Demolished.IntegerValue == -1)
        //                {
        //                    return PhaseType.New;
        //                }
        //                else
        //                {
        //                    return PhaseType.Temporary;
        //                }
        //            }
        //            else if (pC.Id == Demolished)
        //            {
        //                return PhaseType.Demolish;
        //            }
        //        }
        //        else
        //        {
        //            return PhaseType.None;
        //        }
        //    }
        //    catch (Exception ae)
        //    {
        //        Log.Events.Add(new Event
        //        {
        //            Message = ae.Message,
        //            Source = MethodBase.GetCurrentMethod().Name
        //        });
        //    }
        //    return PhaseType.None;
        //}
    }
}
