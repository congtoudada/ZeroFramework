/****************************************************
  文件：NoneLog.cs
  作者：聪头
  邮箱：1322080797@qq.com
  日期：2023-12-28 14:33:46
  功能：Nothing
*****************************************************/
using System;
using System.Collections.Generic;
using System.Text;

namespace ZeroFramework
{
    class NoneLog : ILogger
    {
        public void Debug(object message)
        {
        }

        public void Error(object message)
        {
        }

        public void Fatal(object message)
        {
        }

        public void Info(object message)
        {
        }

        public void Warn(object message)
        {
        }
    }
}
