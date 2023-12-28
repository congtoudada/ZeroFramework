/****************************************************
  文件：ILoggerFactory.cs
  作者：聪头
  邮箱：1322080797@qq.com
  日期：2023-12-28 14:35:26
  功能：
*****************************************************/
using System;
using System.Collections.Generic;
using System.Text;

namespace ZeroFramework
{
    public interface ILoggerFactory
    {
        void Init();

        ILogger Create(Type type);
    }
}
