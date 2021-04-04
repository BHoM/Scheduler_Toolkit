﻿/*
 * This file is part of the Buildings and Habitats object Model (BHoM)
 * Copyright (c) 2015 - 2020, the respective contributors. All rights reserved.
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

<<<<<<< Updated upstream
using BH.oM.Scheduler.Enums;
using System.ComponentModel;

namespace BH.oM.Scheduler.Components
{
    public class Connection
    {
        /***************************************************/
        /**** Properties                                ****/
        /***************************************************/

        [Description("Id of connection needed for searching a list")]
        public virtual string Id { get; set; }

        [Description("Defines the priority for the various connection types")]
        public virtual ConnectionType ConnectionType { get; set; }

        /***************************************************/

        public Connection()
        { ; }
=======
using BH.oM.External.Scheduler.Enums;

namespace BH.oM.External.Scheduler.Components
{
    public class Connection
    {
        public virtual string Id { get; set; }
        public virtual GeometryOverlapType ConnectionType { get; set; }

        public Connection()
        { }
>>>>>>> Stashed changes

        public Connection(string id)
        { Id = id; }

<<<<<<< Updated upstream
        public Connection(string id, ConnectionType connectionType)
=======
        public Connection(string id, GeometryOverlapType connectionType)
>>>>>>> Stashed changes
        {
            Id = id;
            ConnectionType = connectionType;
        }
    }
}
