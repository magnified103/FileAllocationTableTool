using FileAllocationTableTool.Layout;

namespace FileAllocationTableTool
{
    class FileAllocationTable
    {
        //Reserved sector
        ReservedRegion ReservedRegion;
        //File Allocation Table sector
        FileAllocationTableRegion FileAllocationTableRegion;
        //Root Directory sector
        RootDirectoryRegion RootDirectoryRegion;
    }
}
