namespace FileAllocationTableTool.Layout
{
    class DirectoryEntry : ReservedRegion
    {
        byte[] ShortFileName = new byte[8];                 //0x000
        byte[] ShortFileExtention = new byte[3];            //0x008
        byte FileAttributes = new byte();
    }
}
