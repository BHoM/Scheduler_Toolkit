using BH.Engine.External.Scheduler.Compute.Levels;
using System;

namespace BH.Engine.Scheduler.Levels
{
    public static class Clear
    {
        public static void Lists()
        {
            try
            {
                if (Find.lAll.Count > 0) Find.lAll.Clear();
                if (Find.lStructural.Count > 0) Find.lStructural.Clear();
                if (Find.lNonStructural.Count > 0) Find.lNonStructural.Clear();
                if (Find.Level_Link.Count > 0) Find.Level_Link.Clear();
                if (Find.lSub.Count > 0) Find.lSub.Clear();
                if (Find.lSuper.Count > 0) Find.lSuper.Clear();
            }
            catch (Exception ae)
            {
                Reflection.Compute.RecordError(ae.StackTrace); Reflection.Compute.RecordError(ae.Message);
            }
        }
    }
}
