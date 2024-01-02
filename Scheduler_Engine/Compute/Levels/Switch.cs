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

using BH.Engine.Reflection;
using BH.oM.Geometry;
using BH.oM.Spatial.SettingOut;
using System;
using System.ComponentModel.Design;
using System.Linq;


namespace BH.Engine.Scheduler.Compute.Levels
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
                Base.Compute.RecordError(ae.StackTrace); Base.Compute.RecordError(ae.Message);
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
                Base.Compute.RecordError(ae.StackTrace); Base.Compute.RecordError(ae.Message);
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
                Base.Compute.RecordError(ae.StackTrace); Base.Compute.RecordError(ae.Message);
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
                Base.Compute.RecordError(ae.StackTrace); 
                Base.Compute.RecordError(ae.Message);
                if (ae.InnerException != null) Base.Compute.RecordError(ae.InnerException.Message);
            }
            return null;
        }
        
    }
}

