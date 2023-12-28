/****************************************************
  文件：MixLog.cs
  作者：聪头
  邮箱：1322080797@qq.com
  日期：2023-12-28 14:33:34
  功能：Nothing
*****************************************************/

using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

namespace ZeroFramework
{
    public class MixLog : ILogger
    {
        private List<ILogger> _logList;
        
        public MixLog(Type type)
        {
            _logList = new List<ILogger>(2);
            _logList.Add(UnityLog.Instance);
            _logList.Add(new Log4net(type));
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
