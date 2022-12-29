using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimplePipeline
{
    /// <summary>
    /// https://www.codeproject.com/Tips/843127/Simple-Pipeline-Implementation-in-Csharp
    /// 改写了 基于PipeStream 文件操作流
    /// 原文作者没有使用上下文概念 即每一个pipeline中的功能处理数据 至于数据最后的处理是流出还是操作完全由value处理
    /// </summary>
    internal interface IPipelineElement
    {
        bool Alive { get; set; }

        bool IsComplete { get; set; }

        bool SetInput(byte[] data);

        bool TryConnect(IPipelineElement next,out bool success);

        void Proceed();
    }
}
