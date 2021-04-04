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
using BH.oM.Scheduler.Microsoft.Project.Online.Components;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;

namespace BH.oM.Schedule
{
    [Description("LocalTask that can house various scheduling software programme data formats")]
    public class LocalTask
    {
        /***************************************************/
        /**** Properties                                ****/
        /***************************************************/

        public virtual Guid Id { get; set; }
        public virtual Guid ParentId { get; set; }
        public virtual IList<LocalTask> Parent { get; set; } = new List<LocalTask>();
        public virtual Scheduler.Microsoft.Project.Desktop.Components.Task DesktopTask { get; set; }
        public virtual Task OnlineTask { get; set; }
        public virtual TaskCreationInfo Info { get; set; }
        public virtual IList<LocalTask> Children { get; set; } = new List<LocalTask>();
        public virtual WBSLevel LevelType { get; set; }
        public virtual Dictionary<Guid, ConnectionType> Connections { get; set; }

        /***************************************************/
        
=======
using BH.oM.External.Scheduler.Enums;
using BH.oM.External.Scheduler.Microsoft.Project.Online.Components;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BH.oM.External.Scheduler
{
    public class LocalTask
    {
        public virtual Guid Id { get; set; }
        public virtual Guid ParentId { get; set; }
        public virtual LocalTask Parent { get; set; }
        public virtual Microsoft.Project.Desktop.Components.Task DesktopTask { get; set; }
        public virtual Task OnlineTask { get; set; }
        public virtual TaskCreationInfo Info { get; set; }
        public virtual List<LocalTask> Children { get; set; }
        public virtual HeadingType LevelType { get; set; }
        public virtual Dictionary<Guid, GeometryOverlapType> Connections { get; set; }

>>>>>>> Stashed changes
        public LocalTask()
        {
            Children = new List<LocalTask>();
            Info = new TaskCreationInfo();
<<<<<<< Updated upstream
            Connections = new Dictionary<Guid, ConnectionType>();
        }

        public void Add()
        { ; }

        public void Add(string name, bool isManual, WBSLevel levelType)
=======
            Connections = new Dictionary<Guid, GeometryOverlapType>();
        }
        public void Add()
        { }
        public void Add(string name, bool isManual, HeadingType levelType)
>>>>>>> Stashed changes
        {
            Info.Name = name;
            Info.IsManual = isManual;
            Info.Id = Guid.NewGuid();
            Id = Info.Id;
            //Task = pjDoc.CurrentDraft.Tasks.Add(Info);
            //Task = Document.CurrentDraft.Tasks.Add(Info);
            LevelType = levelType;
        }
<<<<<<< Updated upstream
        public void Add(string name, bool isManual, string duration, WBSLevel levelType)
=======
        public void Add(string name, bool isManual, string duration, HeadingType levelType)
>>>>>>> Stashed changes
        {
            Info.Name = name;
            Info.IsManual = isManual;
            Info.Duration = duration;
            Info.Id = Guid.NewGuid();
            Id = Info.Id;
            //Task = pjDoc.CurrentDraft.Tasks.Add(Info);
            //Task = Document.CurrentDraft.Tasks.Add(Info);
            LevelType = levelType;
        }
<<<<<<< Updated upstream
        public void Add(string name, bool isManual, IList<LocalTask> parent, WBSLevel levelType)
        {
            foreach (LocalTask lt in parent)
            {
                Info.Name = name;
                Info.IsManual = isManual;
                Info.ParentId = lt.Id;
                Info.Id = Guid.NewGuid();
                ParentId = lt.Id;
                Parent = parent;
                Id = Info.Id;
                //Task = pjDoc.CurrentDraft.Tasks.Add(Info);
                //Task = Document.CurrentDraft.Tasks.Add(Info);
                if (lt.Children.Count(e => e.Info.Name == name) == 0) lt.Children.Add(this);
                LevelType = levelType;
            }
        }
        public void Add(string name, bool isManual, string duration, IList<LocalTask> parent, WBSLevel levelType)
        {
            foreach (LocalTask lt in parent)
            {
                Info.Name = name;
                Info.IsManual = isManual;
                Info.Duration = duration;
                Info.ParentId = lt.Id;
                Info.Id = Guid.NewGuid();
                ParentId = lt.Id;
                Parent = parent;
                Id = Info.Id;
                //Task = pjDoc.CurrentDraft.Tasks.Add(Info);
                //Task = Document.CurrentDraft.Tasks.Add(Info);
                if (lt.Children.Count(e => e.Info.Name == name) == 0) lt.Children.Add(this);
                LevelType = levelType;
=======
        public void Add(string name, bool isManual, LocalTask parent, HeadingType levelType)
        {
            Info.Name = name;
            Info.IsManual = isManual;
            Info.ParentId = parent.Id;
            Info.Id = Guid.NewGuid();
            ParentId = parent.Id;
            Parent = parent;
            Id = Info.Id;
            //Task = pjDoc.CurrentDraft.Tasks.Add(Info);
            //Task = Document.CurrentDraft.Tasks.Add(Info);
            if (Parent.Children.Count(e => e.Info.Name == name) == 0) Parent.Children.Add(this);
            LevelType = levelType;
        }
        public void Add(string name, bool isManual, string duration, LocalTask parent, HeadingType levelType)
        {
            Info.Name = name;
            Info.IsManual = isManual;
            Info.Duration = duration;
            Info.ParentId = parent.Id;
            Info.Id = Guid.NewGuid();
            ParentId = parent.Id;
            Parent = parent;
            Id = Info.Id;
            //Task = pjDoc.CurrentDraft.Tasks.Add(Info);
            //Task = Document.CurrentDraft.Tasks.Add(Info);
            if (Parent.Children.Count(e => e.Info.Name == name) == 0) Parent.Children.Add(this);
            LevelType = levelType;
        }
        public void Delete(LocalTask t)
        {
            try
            {
                //Document.CurrentDraft.Tasks.Remove(t.Task);
                //bool res = Document.Update();
            }
            catch (Exception ae)
            {
                Engine.Reflection.Compute.RecordError(ae.StackTrace);
                Engine.Reflection.Compute.RecordError(ae.Message);
                if (ae.InnerException != null) Engine.Reflection.Compute.RecordError(ae.InnerException.ToString());
>>>>>>> Stashed changes
            }
        }
    }
}
