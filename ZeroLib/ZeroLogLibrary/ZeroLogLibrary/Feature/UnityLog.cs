/****************************************************
  文件：UnityLog.cs
  作者：聪头
  邮箱：1322080797@qq.com
  日期：2023/11/22 16:07:56
  功能：
*****************************************************/
using System;
using System.Collections;
using System.Collections.Generic;
using log4net;
using UnityEngine;

namespace ZeroFramework
{
    public class UnityLog : ILogger
    {
        public static UnityLog Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new UnityLog();
                }
                return _instance;
            }
        }
        private static UnityLog _instance;

        public void Debug(object message)
        {
            UnityEngine.Debug.Log(message);
        }

        public void Info(object message)
        {
            UnityEngine.Debug.Log(message);
        }

        public void Warn(object message)
        {
            UnityEngine.Debug.LogWarning(message);
        }

        public void Error(object message)
        {
            UnityEngine.Debug.LogError(message);
        }

        public void Fatal(object message)
        {
            UnityEngine.Debug.LogError(message);
        }
    }
}
