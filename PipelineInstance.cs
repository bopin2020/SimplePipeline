using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimplePipeline
{
    internal class PipelineInstance
    {
        List<IPipelineElement> pipelineElements = new List<IPipelineElement>();

        public void Add(IPipelineElement pipelineElement)
        {
            pipelineElements.Add(pipelineElement);
        }

        public void Run()
        {
            int index = 0;
            foreach (var item in pipelineElements)
            {
                item.Proceed();
                if(index < pipelineElements.Count - 1)
                {
                    pipelineElements[index].TryConnect(pipelineElements[index + 1], out bool success);
                    index++;
                }
            }
        }
    }
}
