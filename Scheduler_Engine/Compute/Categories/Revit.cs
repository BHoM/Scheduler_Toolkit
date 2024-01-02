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

using System.Collections.Generic;

namespace BH.Engine.Scheduler.Compute.Categories
{
    public static class Revit
    {
        public static List<string> FirstFix()
        {
            return new List<string>
            {
                "Assemblies",
                "CableTray",
                "CableTrayFitting",
                "CableTrayDrop",
                "CableTrayRiseDrop",
                "CableTrayRun",
                "Conduit",
                "ConduitFitting",
                "ConduitDrop",
                "ConduitRiseDrop",
                "ConduitRun",
                "DuctAccessory",
                "DuctCurves",
                "DuctCurvesInsulation",
                "DuctCurvesLining",
                "DuctFitting",
                "DuctFittingInsulation",
                "DuctFittingLining",
                "DuctInsulations",
                "DuctLinings",
                "DuctSystem",
                "DuctTerminal",
                "FlexDuctCurves",
                "FlexDuctCurvesInsulation",
                "ElectricalEquipment",
                "MechanicalEquipment",
                "PipeSegments",
                "PipeInsulations",
                "PipeCurves",
                "PipeCurvesInsulation",
                "PipeFitting",
                "PipeFittingInsulation",
                "PipeAccessory",
                "FlexPipeCurves",
                "FlexPipeCurvesInsulation",
                "Wire",
                "WireInsulations"
            };
        }

        public static List<string> Furnishings()
        {
            return new List<string>
            {
                "Furniture",
                "Planting",
                "Site"
            };
        }

        public static List<string> Groundworks()
        {
            return new List<string>
            {
                "BuildingPad",
                "Topography"
            };
        }

        public static List<string> NonStructural()
        {
            return new List<string>
            {
                "Casework",
                "Ceilings",
                "Columns",
                "CurtainWallPanels",
                "Doors",
                "Floors",
                "GenericModel",
                "StairsRailing",
                "RailingTopRail",
                "RoofSoffit",
                "Cornices",
                "Reveals",
                "Walls"
            };
        }

        public static List<string> SecondFix()
        {
            return new List<string>
            {
                "CommunicationDevices",
                "DataDevices",
                "ElectricalFixtures",
                "FireAlarmDevices",
                "Floors",
                "Gutter",
                "LightingDevices",
                "LightingFixtures",
                "NurseCallDevices",
                "PlumbingFixtures",
                "SecurityDevices",
                "SpecialityEquipment",
                "Sprinklers",
                "TelephoneDevices"
            };
        }

        public static List<string> Structural()
        {
            return new List<string>
            {
                "BuildingPad",
                "EdgeSlab",
                "Rebar",
                "StructConnections",
                "StructuralColumns",
                "StructuralFoundation",
                "StructuralFraming",
                "StructuralStiffener",
                "StructuralTruss",
                "Truss"
            };
        }

        public static List<string> StructuralHybrid()
        {
            return new List<string>
            {
                "Assemblies",
                "Extrusions",
                "Floors",
                "Ramps",
                "Roofs",
                "StairsLandings",
                "StairsRuns",
                "Stairs",
                "Walls",
                "Windows"
            };
        }
    }
}

