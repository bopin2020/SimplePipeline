using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimplePipeline
{
    internal class DecryptValue : IPipelineElement
    {
        public bool Alive { get; set; }
        public bool IsComplete { get; set; }

        byte[] RawData { get; set; }

        public void Proceed()
        {
            Console.WriteLine("解密数据");
            RawData = RawData.xorEncOrDec("this is a xor key");
            if (RawData.SequenceEqual(Program.data))
            {
                Console.WriteLine("解密成功");
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
