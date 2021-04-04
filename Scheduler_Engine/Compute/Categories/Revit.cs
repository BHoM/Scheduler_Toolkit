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
