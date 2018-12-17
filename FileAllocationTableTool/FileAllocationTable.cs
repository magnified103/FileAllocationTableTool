using FileAllocationTableTool.Layout;

namespace FileAllocationTableTool
{
    /// <summary>
    /// A fully design of a FAT file system.
    /// </summary>
    class FileAllocationTable
    {
        //Reserved sector
        ReservedRegion ReservedRegion;
        //File Allocation Table sector
        FileAllocationTableRegion FileAllocationTableRegion;
        //Root Directory sector
        RootDirectoryRegion RootDirectoryRegion;


        //Function
        public void GetDirectoryEntries()
        {

        }
    }
}
