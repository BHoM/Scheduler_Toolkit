using BH.oM.Spatial.SettingOut;
using BH.oM.Geometry;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BH.Engine.Scheduler.Compute.Levels
{
    public static class Find
    {
        public static IList<Level> lAll = new List<Level>();
        public static IList<Link> Level_Link = new List<Link>();
        public static IList<Level> lStructural = new List<Level>();
        public static IList<Level> lNonStructural = new List<Level>();      //This will be required to fill the DataGridView comboboxes
        public static IList<Level> lSub = new List<Level>();
        public static IList<Level> lSuper = new List<Level>();
        public static Level FromLocation(Point LocationLevel)
        {
            Level lOut = default;
            try
            {
                if (lAll.Count(l => l.Elevation < LocationLevel.Z) > 0)
                {
                    //Find nearest level below the location point
                    lOut = lAll.First(l => l.Elevation < LocationLevel.Z);
                }
                else
                {
                    //Get the lowest level if there are any levels below the location point
                    lOut = lAll.First(l1 => l1.Elevation == lAll.Min(l => l.Elevation));
                }
            }
            catch (Exception ae)
            {
                Base.Compute.RecordError(ae.StackTrace); 
                Base.Compute.RecordError(ae.Message); 
                if (ae.InnerException != null) Base.Compute.RecordError(ae.InnerException.ToString());
            }
            return lOut;
        }
    }
}
