/*
 * This file is part of the Buildings and Habitats object Model (BHoM)
 * Copyright (c) 2015 - 2023, the respective contributors. All rights reserved.
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


//using BH.oM.Spatial.SettingOut;
using System;
using System.Data;
using System.Linq;
//using System.Windows.Forms;

namespace BH.Engine.Scheduler.Compute.Levels
{
    public static class Combine
    {
        public static bool Levels()
        {
            //try
            //{
            //    //Get all structural levels and order by lowest first
            //    Find.lAll = new FilteredElementCollector(Database.APIComponents.oDoc).OfClass(typeof(Level))
            //                                        .Cast<Level>().OrderBy(lt => lt.Elevation).ToList();

            //    //Get all structural levels and order by lowest first
            //    Find.lStructural = new FilteredElementCollector(Database.APIComponents.oDoc).OfClass(typeof(Level))
            //        .Where(l => l.get_Parameter(BuiltInParameter.LEVEL_IS_STRUCTURAL).AsInteger() == 1).Cast<Level>().ToList();
            //    Find.lStructural = Find.lStructural.OrderBy(lt => lt.Elevation).ToList();

            //    if (Find.lStructural.Count == 0)
            //    {
            //        TaskDialog.Show("No Structural Levels", "No 'Structural levels are present within the current model." + Environment.NewLine + Environment.NewLine +
            //            "This add-in only will only group elements via 'Structural' levels. Routine has been cancelled.");
            //        return false;
            //    }

            //    //Get all non-structural levels
            //    Find.lNonStructural = new FilteredElementCollector(Database.APIComponents.oDoc).OfClass(typeof(Level))
            //        .Where(l => l.get_Parameter(BuiltInParameter.LEVEL_IS_STRUCTURAL).AsInteger() == 0).Cast<Level>().ToList();

            //    //Determine which level is closest to the relevant structural level
            //    foreach(Level l in Find.lNonStructural)
            //    {
            //        var minDistance = Find.lStructural.Min(n => Math.Abs(l.Elevation - n.Elevation));
            //        Level closest = Find.lStructural.First(n => Math.Abs(l.Elevation - n.Elevation) == minDistance);
            //        Find.Level_Link.Add(new Link(closest, l));
            //    }

            //    Forms.LevelConsolidation lc = new Forms.LevelConsolidation();
            //    lc.ShowDialog();

            //    if (lc.DialogResult == DialogResult.OK)
            //    {
            //        Find.lSub = Find.lStructural.Where(e => e.Elevation < 0).OrderByDescending(e => e.Elevation).ToList();
            //        Find.lSuper = Find.lStructural.Where(e => e.Elevation >= 0).OrderBy(e => e.Elevation).ToList();
            //        //RadioButton rbOnline = (RadioButton)lc.Controls.Find("rbProjectOnline", true).First();
            //        //if (rbOnline.Checked) Project.Settings.IsOnline = true;
            //        //RadioButton rbDesktop = (RadioButton)lc.Controls.Find("rbProjectDesktop", true).First();
            //        //if (rbDesktop.Checked) Project.Settings.IsDesktop = true;
            //        return true;
            //    }
            //    else
            //    { return false; }
            //}
            //catch (Exception ae)
            //{
            //    Base.Compute.RecordError(ae.StackTrace); 
            //    Base.Compute.RecordError(ae.Message); 
            //    if (ae.InnerException != null) Base.Compute.RecordError(ae.InnerException.ToString());
            //    return false;
            //}
            return true;
        }
    }
}
