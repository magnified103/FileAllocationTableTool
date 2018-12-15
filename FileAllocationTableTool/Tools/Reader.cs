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
        public byte[] ReadFromOffset(int offset, int count)
        {
            byte[] result = new byte[count];
            VolumeImage.BaseStream.Read(result, offset, count);
            return result;
        }
    }
}
