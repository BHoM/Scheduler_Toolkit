using System;

namespace BH.Engine.Scheduler.Compute.Levels
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
                Base.Compute.RecordError(ae.StackTrace);
                Base.Compute.RecordError(ae.Message);
            }
        }
    }
}
