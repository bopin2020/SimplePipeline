using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimplePipeline
{
    internal class Program
    {
        public static byte[] data = File.ReadAllBytes(@"c:\windows\system32\cmd.exe").Compress();

        static void Main(string[] args)
        {
            PipelineInstance pipelineInstance = new PipelineInstance();
            // Step 1. 初始化数据压缩 加密
            pipelineInstance.Add(new EncryptValue(data));
            // Step 2. 解密数据 和原始压缩数据对比
            pipelineInstance.Add(new DecryptValue());
            // Step 3. 解压缩数据 和 原始未压缩数据对比
            pipelineInstance.Add(new DecompressValue());
            pipelineInstance.Run();


            Console.ReadKey();
        }
    }
}
