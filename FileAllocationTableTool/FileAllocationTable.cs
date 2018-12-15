using FileAllocationTableTool.Layout;

namespace FileAllocationTableTool
{
    class FileAllocationTable
    {
        //Reserved sector
        ReservedRegion ReservedRegion;
        //File Allocation Table sector
        FATRegion FATRegion;
        //Root Directory sector
        RootDirectoryRegion RootDirectoryRegion;
    }
}
