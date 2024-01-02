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

