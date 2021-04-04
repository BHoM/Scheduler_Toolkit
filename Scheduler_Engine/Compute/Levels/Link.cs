using BH.oM.Geometry.SettingOut;

namespace BH.Engine.External.Scheduler.Compute.Levels
{
    public class Link
    {
        public virtual Level Structural { get; set; }
        public virtual Level NonStructural { get; set; }
        public Link(Level structural, Level nonstructural)
        {
            Structural = structural;
            NonStructural = nonstructural;
        }
    }
}
