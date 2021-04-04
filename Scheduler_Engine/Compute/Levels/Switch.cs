using BH.Engine.Reflection;
using BH.oM.Geometry;
using BH.oM.Geometry.SettingOut;
using System;
using System.ComponentModel.Design;
using System.Linq;


namespace BH.Engine.External.Scheduler.Compute.Levels
{
    public static class Switch
    {
        public static Level Association(Level LevelToCheck, Point l)
        {
            try
            {
                if(null == LevelToCheck)
                {
                    return NullLevelOverride(l);
                }
                if(Find.lStructural.Count(lv => lv.Name == LevelToCheck.Name) == 1)
                {
                    return LevelToCheck;
                }
                else
                {
                    Link ll = Find.Level_Link.First(lv => lv.NonStructural.Name == LevelToCheck.Name);
                    return ll.Structural;
                }
            }
            catch (Exception ae)
            {
                Reflection.Compute.RecordError(ae.StackTrace); Reflection.Compute.RecordError(ae.Message);
            }
            return null;
        }

        public static Level Association(Level LevelToCheck, ICurve l)
        {
            try
            {
                if (null == LevelToCheck)
                {
                    return NullLevelOverride(l);
                }
                if (Find.lStructural.Count(lv => lv.Name == LevelToCheck.Name) == 1)
                {
                    return LevelToCheck;
                }
                else
                {
                    Link ll = Find.Level_Link.First(lv => lv.NonStructural.Name == LevelToCheck.Name);
                    return ll.Structural;
                }
            }
            catch (Exception ae)
            {
                Reflection.Compute.RecordError(ae.StackTrace); Reflection.Compute.RecordError(ae.Message);
            }
            return null;
        }

        private static Level NullLevelOverride(Point loc)
        {
            try
            {
                Point pt = loc;
                double dblL = pt.Z - Find.lStructural.Where(lv => lv.Elevation <= pt.Z).Min(lv => pt.Z - lv.Elevation);
                Level l = Find.lStructural.First(lv => lv.Elevation == dblL);
                return l;
            }
            catch (Exception ae)
            {
                Reflection.Compute.RecordError(ae.StackTrace); Reflection.Compute.RecordError(ae.Message);
            }
            return null;
        }

        private static Level NullLevelOverride(ICurve loc)
        {
            try
            {
                Point Start = new Point();
                Point End = new Point();

                if (loc.GetType() == typeof(Arc))
                {
                    Arc c = loc as Arc;
                    Start = c.CoordinateSystem.Origin;
                    End = new Point()
                    {
                        X = c.CoordinateSystem.Origin.X + 10,
                        Y = c.CoordinateSystem.Origin.Y + 10,
                        Z = c.CoordinateSystem.Origin.Z
                    };
                }

                if (loc.GetType() == typeof(PolyCurve))
                {
                    PolyCurve c = loc as PolyCurve;
                    //Start = c.Curves[0].
                    //End = new Point()
                    //{
                    //    X = c.CoordinateSystem.Origin.X + 10,
                    //    Y = c.CoordinateSystem.Origin.Y + 10,
                    //    Z = c.CoordinateSystem.Origin.Z
                    //};
                }

                if (loc.GetType() == typeof(Line))
                {
                    Line c = loc as Line;
                    Start = c.Start;
                    End = c.End;
                }

                double dblStart = Start.Z - Find.lStructural.Where(lv => lv.Elevation <= Start.Z).Min(lv => Start.Z - lv.Elevation);
                double dblEnd = End.Z - Find.lStructural.Where(lv => lv.Elevation <= End.Z).Min(lv => End.Z - lv.Elevation);
                double dblL;
                if(dblStart <= dblEnd)
                {
                    dblL = dblStart;
                }
                else
                {
                    dblL = dblEnd;
                }
                Level l = Find.lStructural.First(lv => lv.Elevation == dblL);
                return l;
            }
            catch (Exception ae)
            {
                Reflection.Compute.RecordError(ae.StackTrace); 
                Reflection.Compute.RecordError(ae.Message);
                if (ae.InnerException != null) Reflection.Compute.RecordError(ae.InnerException.Message);
            }
            return null;
        }
        
    }
}
