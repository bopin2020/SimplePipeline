using System;
using System.Collections.Generic;
using System.IO.Compression;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimplePipeline
{
    internal static class DataHandleExt
    {
        public static byte[] xorEncOrDec(this byte[] inputData, string keyPhrase)
        {
            byte[] bufferBytes = new byte[inputData.Length];
            for (int i = 0; i < inputData.Length; i++)
            {
                bufferBytes[i] = (byte)(inputData[i] ^ Encoding.UTF8.GetBytes(keyPhrase)[i % Encoding.UTF8.GetBytes(keyPhrase).Length]);
            }
            return bufferBytes;
        }

        public static byte[] Decompress(this byte[] zippedData)
        {
            MemoryStream ms = new MemoryStream(zippedData);
            GZipStream compressedzipStream = new GZipStream(ms, CompressionMode.Decompress);
            MemoryStream outBuffer = new MemoryStream();
            byte[] block = new byte[1024];
            while (true)
            {
                int bytesRead = compressedzipStream.Read(block, 0, block.Length);
                if (bytesRead <= 0)
                    break;
                else
                    outBuffer.Write(block, 0, bytesRead);
            }
            compressedzipStream.Close();
            return outBuffer.ToArray();
        }

        public static byte[] Compress(this byte[] data)
        {
            try
            {
                MemoryStream ms = new MemoryStream();
                GZipStream zip = new GZipStream(ms, CompressionMode.Compress, true);
                zip.Write(data, 0, data.Length);
                zip.Close();
                byte[] buffer = new byte[ms.Length];
                ms.Position = 0;
                ms.Read(buffer, 0, buffer.Length);
                ms.Close();
                return buffer;

            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
    }
}
