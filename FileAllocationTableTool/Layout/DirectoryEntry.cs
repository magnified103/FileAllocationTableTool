namespace FileAllocationTableTool.Layout
{
    class DirectoryEntry : ReservedRegion
    {
        byte[] ShortFileName = new byte[8];
        byte[] ShortFileExtention = new byte[3];
    }
}
