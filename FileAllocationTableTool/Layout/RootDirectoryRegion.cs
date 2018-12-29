using System.Collections.Generic;

namespace FileAllocationTableTool.Layout
{
    /// <summary>
    /// Root Directory region. Store informations about the files and directories located in root directory.
    /// </summary>
    /*
    Note:
        StartOffset = (ReservedSector + NumberOfFATs * SectorsPerFat) * BytesPerSector
        LengthInSectors = MaxRootDirEntries * 32 / BytesPerSector
        LenthInBytes = MaxRootDirEntries * 32
    */
    class RootDirectoryRegion
    {

    }
}
