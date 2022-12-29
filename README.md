# SimplePipeline

## IPipelineElement

> 接口定义

```c#
    internal interface IPipelineElement
    {
        bool Alive { get; set; }

        bool IsComplete { get; set; }

        bool SetInput(byte[] data);

        bool TryConnect(IPipelineElement next,out bool success);

        void Proceed();
    }
```



```mermaid
graph TD
	pipelineStart --> | 第一个功能给定数据 | 字节数据 --> 加密 --> 解密 --> 解压缩 --> | 处理流出的数据 | pipelineEnd
```



![image-20221230075049445](image/image-20221230075049445.png)
