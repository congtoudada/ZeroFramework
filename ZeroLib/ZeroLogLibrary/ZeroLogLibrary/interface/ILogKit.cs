/****************************************************
  文件：ILogKit.cs
  作者：聪头
  邮箱：1322080797@qq.com
  日期：2023-12-28 14:35:40
  功能：
*****************************************************/
using System;
using System.Collections.Generic;
using System.Text;

namespace ZeroFramework
{
    public interface ILogKit
    {
        void SetEnable(bool isEnable);
        void SetLoggerFactory(ILoggerFactory factory);

        ILogger AllocateLogger(Type type);

        ILogger AllocateLoggerOnce(Type type);

        void SetWhiteFilter(List<Type> whiteList);

        void Debug(object message, Type type);

        void Info(object message, Type type);

        void Warn(object message, Type type);

        void Error(object message, Type type);

        void Fatal(object message, Type type);

        void DebugOnce(object message, Type type);

        void InfoOnce(object message, Type type);

        void WarnOnce(object message, Type type);

        void ErrorOnce(object message, Type type);

        void FatalOnce(object message, Type type);
    }
}
