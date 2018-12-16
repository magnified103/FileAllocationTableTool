using FileAllocationTableTool.Tools;

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
        |   0x012   |   2       |   Last access date                            |
        |___________|___________|_______________________________________________|
        |   0x014   |   2       |   High 2 bytes of first cluster in FAT32      |
        |___________|___________|_______________________________________________|
        |   0x016   |   2       |   Last modified time                          |
        |___________|___________|_______________________________________________|
        |   0x018   |   2       |   Last modified date                          |
        |___________|___________|_______________________________________________|
        |   0x01A   |   2       |   Start of file in clusters in FAT12 and      |
        |           |           |   FAT16. Low 2 bytes of first cluster in      |
        |           |           |   FAT32; with the high 2 bytes stored at      |
        |           |           |   offset 0x014.                               |
        |___________|___________|_______________________________________________|
        |   0x01C   |   4       |   File size in bytes. Entries with the Volume |
        |           |           |   Label or Subdirectory flag set should have  |
        |           |           |   a size of 0.                                |
        |___________|___________|_______________________________________________|
        */
        /*
        File Attributes
         ___________________________________________
        |   Bit     |   Mask    |   Description     |
        |___________|___________|___________________|
        |   0       |   0x001   |   Read Only       |
        |___________|___________|___________________|
        |   1       |   0x002   |   Hidden          |
        |___________|___________|___________________|
        |   2       |   0x004   |   System          |
        |___________|___________|___________________|
        |   3       |   0x008   |   Volume Label    |
        |___________|___________|___________________|
        |   4       |   0x010   |   Subdirectory    |
        |___________|___________|___________________|
        |   5       |   0x020   |   Archive         |
        |___________|___________|___________________|
        |   6       |   0x040   |   Device          |
        |___________|___________|___________________|
        |   7       |   0x080   |   Reserved        |
        |___________|___________|___________________|

        Note: for LFN (Long File Name) entry attribute always has value of 0x0F (00001111)
        */
        /*
        Example:
        0x010 has value of F3 - 11110011
        0x011 has value of 42 - 01000010

        Reverse the order of 2 bytes:
             0x011     |     0x010
               |       |       |
               v       |       v
        0 1 0 0 0 0 1|0|1 1 1|1 0 0 1 1
        -___________-|-_____-|-_______-
              x          y        z
        Year = x + 1980 = 33 + 1980 = 2013
        Month = y = 7
        Day = z = 19

        Example:
        0x00E has value of 49 - 01001001
        0x00F has value of 9B - 10011011

        Reverse the order of 2 bytes:
             0x00F     |     0x00E
               |       |       |
               v       |       v
        1 0 0 1 1|0 1 1|0 1 0|0 1 0 0 1
        -_______-|-_________-|-_______-
            x          y          z
        Hours = x = 19
        Minutes = y = 26
        Seconds = z * 2 = 9 * 2 = 18
        */
        //File attributes
        byte FileAttributes = new byte();                       //0x00B
        byte Type = new byte();                                 //0x00C
        byte[] StartOfFileInClusterForFAT12_16 = new byte[2];   //0x01A

        //Directory entry
        byte[] ShortFileName = new byte[8];                     //0x000
        byte[] ShortFileExtention = new byte[3];                //0x008
        /*
            Attributes
            0x00B-0x001 byte
        */
        /*
            Type (reserved)
            0x00C-0x001 byte
        */
        byte CreateTime_10msUnit = new byte();                  //0x00D
        byte[] CreateTime = new byte[2];                        //0x00E
        byte[] CreateDate = new byte[2];                        //0x010
        byte[] LastAccessDate = new byte[2];                    //0x012
        /*
            0x014-0x002 bytes
        */
        byte[] LastModifiedTime = new byte[2];                  //0x016
        byte[] LastModifiedDate = new byte[2];                  //0x018
        /*
            First cluster of file
            0x01A-0x002 bytes
        */
        byte[] FileSizeInBytes = new byte[4];                   //0x01C

        //Long File Name entry

        byte SequenceNumber = new byte();                       //0x000
        byte[] FirstNameCharacters = new byte[10];              //0x001
        /*
            Attributes - 0x0F
            0x00B-0x001 byte
        */
        /*
            Type - 0x00
            0x00C-0x001 byte
        */
        byte FileNameChecksum = new byte();                     //0x00D
        byte[] SecondNameCharacters = new byte[12];             //0x00E
        /*
            First cluster of file - 0x0000
            0x01A-0x002 bytes
        */
        byte[] ThirdNameCharacters = new byte[4];               //0x01C
        //Directory properties
        uint DirectoryCounts = new uint();
        bool IsLongFileName = new bool();
        public DirectoryEntry(int offset, ref Reader image)
        {

        }
    }
}
