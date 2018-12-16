using FileAllocationTableTool.Tools;

namespace FileAllocationTableTool.Layout
{
    class FileAttributes
    {
        byte Attributes;
        bool ReadOnly;
        bool Hidden;
        bool System;
        bool VolumeLabel;
        bool Subdirectory;
        bool Archive;
        bool Device;
        bool Reserved;

        public FileAttributes()
        {
            Attributes = new byte();
            ReadOnly = new bool();
            Hidden = new bool();
            System = new bool();
            VolumeLabel = new bool();
            Subdirectory = new bool();
            Archive = new bool();
            Device = new bool();
            Reserved = new bool();
        }

        public FileAttributes(byte In)
        {
            Attributes = In;
            ReadOnly = Converter.ReadBitAtPosition(In, 1);
            Hidden = Converter.ReadBitAtPosition(In, 2);
            System = Converter.ReadBitAtPosition(In, 3);
            VolumeLabel = Converter.ReadBitAtPosition(In, 4);
            Subdirectory = Converter.ReadBitAtPosition(In, 5);
            Archive = Converter.ReadBitAtPosition(In, 6);
            Device = Converter.ReadBitAtPosition(In, 7);
            Reserved = Converter.ReadBitAtPosition(In, 8);
        }

        public bool IsLongFileName()
        {
            return (Attributes == 0x0F);
        }
    }
}
