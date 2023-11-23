/****************************************************
  文件：LogContainer.cs
  作者：聪头
  邮箱：1322080797@qq.com
  日期：2023/11/22 16:29:42
  功能：Nothing
*****************************************************/

using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

namespace ZeroFramework
{
    public class MixLog : ILogTool
    {
        private ILogTool[] _logList;
        
        
        public MixLog(Type type)
        {
            _logList = new ILogTool[2];
            _logList[0] = new UnityLog();
            _logList[1] = new Log4net(type);
        }

        public void Debug(object message)
        {
            foreach (var logger in _logList)
            {
                logger.Debug(message);
            }
        }

        public void Info(object message)
        {
            foreach (var logger in _logList)
            {
                logger.Info(message);
            }
        }

        public void Warn(object message)
        {
            foreach (var logger in _logList)
            {
                logger.Warn(message);
            }
        }

        public void Error(object message)
        {
            foreach (var logger in _logList)
            {
                logger.Error(message);
            }
        }

        public void Fatal(object message)
        {
            foreach (var logger in _logList)
            {
                logger.Fatal(message);
            }
        }
    }
}
