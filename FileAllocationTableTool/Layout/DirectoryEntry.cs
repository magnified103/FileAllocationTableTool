namespace FileAllocationTableTool.Layout
{
    /*
        Directory entry
    */
    class DirectoryEntry : RootDirectoryRegion
    {
        /*
         _______________________________________________________________________
        |   Offset  |   Length  |                   Contents                    |
        |___________|___________|_______________________________________________|
        |   0x000   |   8       |   Short file name                             |
        |___________|___________|_______________________________________________|
        |   0x008   |   3       |   Short file extension                        |
        |___________|___________|_______________________________________________|
        |   0x00B   |   1       |   File Attributes                             |
        |___________|___________|_______________________________________________|
        |   0x00C   |   1       |   Reserved                                    |
        |___________|___________|_______________________________________________|
        |   0x00D   |   1       |   Create time, fine resolution: 10 ms units   |
        |___________|___________|_______________________________________________|
        |   0x00E   |   2       |   Create time (hour, minute and second)       |
        |___________|___________|_______________________________________________|
        |   0x010   |   2       |   Create date (year, month and day)           |
        |___________|___________|_______________________________________________|
        |   0x012   |   2       |   Reserved                                    |
        |___________|___________|_______________________________________________|
        |   0x014   |   2       |   Reserved                                    |
        |___________|___________|_______________________________________________|
        |   0x016   |   2       |   Last modified time                          |
        |___________|___________|_______________________________________________|
        |   0x018   |   2       |   Last modified date                          |
        |___________|___________|_______________________________________________|
        |   0x01A   |   2       |   Start of file in clusters in FAT12 and      |
        |           |           |   FAT16. Low two bytes of first cluster in    |
        |           |           |   FAT32; with the high two bytes stored at    |
        |           |           |   offset 0x014.                               |
        |___________|___________|_______________________________________________|
        |   0x01C   |   4       |   File size in bytes. Entries with the Volume |
        |           |           |   Label or Subdirectory flag set should have  |
        |           |           |   a size of 0.                                |
        |___________|___________|_______________________________________________|
        */
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
