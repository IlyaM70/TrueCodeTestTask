using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ByteStreamSplitter
{
    public static class ByteArraySplitter
    {
        public static byte[][] Split(byte[] input, byte separator)
        {
            var subArrays = new List<byte[]>();
            int start = 0;
            for (int i = 0; i <= input.Length; ++i)
            {
                if (input.Length == i || input[i] == separator)
                {
                    if (i - start > 0)
                    {
                        var destination = new byte[i - start];
                        Array.Copy(input, start, destination, 0, i - start);
                        subArrays.Add(destination);
                    }
                    start = i + 1;
                }
            }

            return subArrays.ToArray();
        }
    }
}
