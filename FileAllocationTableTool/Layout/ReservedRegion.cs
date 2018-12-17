using System;

namespace FileAllocationTableTool.Layout
{
    /// <summary>
    /// Reserved sector. Contains boot sector and some reserved sectors (optional).
    /// </summary>
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
