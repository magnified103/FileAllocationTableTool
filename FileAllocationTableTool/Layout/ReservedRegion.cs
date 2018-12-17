using System;

namespace FileAllocationTableTool.Layout
{
    /*
        Reserved sector
    */
    public class ReservedRegion
    {
        BootSector BootSector;

        //Functions
        public int BytesPerCluster()
        {
            return Convert.ToInt32(BootSector.BytesPerSector) * Convert.ToInt32(BootSector.SectorsPerCluster);
        }
    };
}
