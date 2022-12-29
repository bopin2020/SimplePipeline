using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimplePipeline
{
    internal class DecompressValue : IPipelineElement
    {
        public bool Alive { get; set; }
        public bool IsComplete { get; set; }

        byte[] RawData { get; set; }

        public void Proceed()
        {
            Console.WriteLine("解压缩数据");
            if (RawData.Decompress().SequenceEqual(Program.data.Decompress()))
            {
                Console.WriteLine("解压缩成功");
            }
            IsComplete = true;
        }
        public bool SetInput(byte[] data)
        {
            Alive = true;
            IsComplete = false;
            RawData = data;
            return true;
        }

        public bool TryConnect(IPipelineElement next, out bool success)
        {
            success = false;
            try
            {
                next.SetInput(RawData);
                IsComplete = true;
                success = true;
            }
            catch (Exception)
            {
                Alive = false;
                IsComplete = true;
            }
            return success;
        }
    }
}
