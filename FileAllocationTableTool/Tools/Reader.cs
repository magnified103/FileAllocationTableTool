using System;
using System.IO;

namespace FileAllocationTableTool.Tools
{
    class Reader
    {
        StreamReader VolumeImage;
        public Reader(string PathToImage)
        {
            VolumeImage = new StreamReader(new FileStream(PathToImage, FileMode.Open));
        }
        public bool IsNull()
        {
            return (VolumeImage == null);
        }
        public byte[] ReadFromOffset(int offset, int count)
        {
            byte[] result = new byte[count];
            VolumeImage.BaseStream.Position = offset;
            for (int i = 0; i < count; i++)
            {
                result[i] = Convert.ToByte(VolumeImage.BaseStream.ReadByte());
            }
            return result;
        }
        public byte ReadAtOffset(int offset)
        {
            byte result = new byte();
            VolumeImage.BaseStream.Position = offset;
            result = Convert.ToByte(VolumeImage.BaseStream.ReadByte());
            return result;
        }
    }
}
