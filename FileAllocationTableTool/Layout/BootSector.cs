namespace FileAllocationTableTool.Layout
{
    /// <summary>
    /// Boot sector
    /// </summary>
    class BootSector : ReservedRegion
    {
        /*
         _______________________________________________________________________
        |   Offset  |   Length  |                   Contents                    |
        |___________|___________|_______________________________________________|
        |   0x000   |   3       |   Jump instruction                            |
        |___________|___________|_______________________________________________|
        |   0x003   |   8       |   OEM name                                    |
        |___________|___________|_______________________________________________|
        |   0x00B   |   2       |   Bytes per logical sector                    |
        |___________|___________|_______________________________________________|
        |   0x00D   |   1       |   Logical sectors per cluster                 |
        |___________|___________|_______________________________________________|
        |   0x00E   |   2       |   Count of reserved logical sectors           |
        |___________|___________|_______________________________________________|
        |   0x010   |   1       |   Number of File Allocation Tables            |
        |___________|___________|_______________________________________________|
        |   0x011   |   2       |   Maximum number of FAT12 or FAT16 root       |
        |           |           |   directory entries                           |
        |___________|___________|_______________________________________________|
        |   0x013   |   2       |   Total logical sectors (if zero, use 4       |
        |           |           |   byte value at offset 0x020)                 |
        |___________|___________|_______________________________________________|
        |   0x015   |   1       |   Media descriptor                            |
        |___________|___________|_______________________________________________|
        |   0x016   |   2       |   Logical sectors per File Allocation         |
        |           |           |   Table for FAT12/FAT16. FAT32 sets this      |
        |           |           |   to 0 and uses the 32-bit value at offset    |
        |           |           |   0x024 instead                               |
        |___________|___________|_______________________________________________|
        |   0x018   |   2       |   Physical sectors per track                  |
        |___________|___________|_______________________________________________|
        |   0x01A   |   2       |   Number of heads for disks                   |
        |___________|___________|_______________________________________________|
        |   0x01C   |   4       |   Count of hidden sectors preceding the       |
        |           |           |   partition that contains this FAT volume     |
        |___________|___________|_______________________________________________|
        |   0x020   |   4       |   Total logical sectors (if greater than      |
        |           |           |   65535; otherwise, see offset 0x013)         |
        |___________|___________|_______________________________________________|
        |   0x024   |   2       |   Physical drive number                       |
        |___________|___________|_______________________________________________|
        |   0x026   |   1       |   Extended boot signature                     |
        |___________|___________|_______________________________________________|
        |   0x027   |   4       |   Volume ID (serial number)                   |
        |___________|___________|_______________________________________________|
        |   0x02B   |   11      |   Partition Volume Label                      |
        |___________|___________|_______________________________________________|
        |   0x036   |   8       |   File system type                            |
        |___________|___________|_______________________________________________|
        |   0x03E   |   448     |   File system and operating system specific   |
        |           |           |   boot code                                   |
        |___________|___________|_______________________________________________|
        |   0x1FE   |   2       |   Boot sector signature (0x55 0xAA)           |
        |___________|___________|_______________________________________________|
        */
        byte[] JumpInstruction = new byte[3];               //0x000
        byte[] OEMName = new byte[8];                       //0x003
        public ushort BytesPerSector = new ushort();        //0x00B
        public byte SectorsPerCluster = new byte();         //0x00D
        ushort ReservedSectors = new ushort();              //0x00E
        byte FileAllocationTables = new byte();             //0x010
        ushort MaxFAT12_16RootDirEntries = new ushort();    //0x011
        ushort TotalSectors = new ushort();                 //0x013
        byte MediaDescriptor = new byte();                  //0x015
        ushort SectorsPerFATForFAT12_16 = new ushort();     //0x016
        ushort SectorsPerTrack = new ushort();              //0x018
        ushort Heads = new ushort();                        //0x01A
        uint HiddenSectors = new uint();                    //0x01C
        uint AdditionalTotalSector = new uint();            //0x020
        ushort PhysicalDriveNumber = new ushort();          //0x024
        byte ExtendedBootSignature = new byte();            //0x026
        uint VolumeID = new uint();                         //0x027
        byte[] VolumeLabel = new byte[11];                  //0x02B
        byte[] FileSystemID = new byte[8];                  //0x036
        /*
            0x03E-0x1C0 bytes
        */
        byte[] Signature = new byte[2];                     //0x1FE
    }
}
