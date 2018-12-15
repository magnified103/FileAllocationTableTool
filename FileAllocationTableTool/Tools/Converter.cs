using System;
using System.Linq;
using System.Text;

namespace FileAllocationTableTool.Tools
{
    static class Converter
    {
        //Get numberic value from bytes which numberred from the least significant end
        public static byte ReadNumbericValue_8(byte In)
        {
            return In;
        }
        public static ushort ReadNumbericValue_16(byte[] In)
        {
            string result = string.Join(string.Empty, In.Reverse().Select(x => Convert.ToString(x, 2).PadLeft(8, '0')));
            return Convert.ToUInt16(result, 2);
        }
        public static uint ReadNumbericValue_32(byte[] In)
        {
            string result = string.Join(string.Empty, In.Reverse().Select(part => Convert.ToString(part, 2).PadLeft(8, '0')));
            return Convert.ToUInt32(result, 2);
        }
        //Get string value from bytes
        public static string ReadStringValue(byte[] In)
        {
            return Encoding.ASCII.GetString(In);
        }
    }
}
