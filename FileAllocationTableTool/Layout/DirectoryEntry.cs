namespace FileAllocationTableTool.Layout
{
    class DirectoryEntry : ReservedRegion
    {
        byte[] ShortFileName = new byte[8];                     //0x000
        byte[] ShortFileExtention = new byte[3];                //0x008
        byte FileAttributes = new byte();                       //0x00B
        /*
            0x00C-0x001 byte
        */
        byte CreateTime_10msUnit = new byte();                  //0x00D
        byte[] CreateTime = new byte[2];                        //0x00E
        byte[] CreateDate = new byte[2];                        //0x010
        /*
            0x012-0x002 bytes
        */
        /*
            0x014-0x002 bytes
        */
        byte[] LastModifiedTime = new byte[2];                  //0x016
        byte[] LastModifiedDate = new byte[2];                  //0x018
        byte[] StartOfFileInClusterForFAT12_16 = new byte[2];   //0x01A
        byte[] FileSizeInBytes = new byte[4];                   //0x01C
    }
}
