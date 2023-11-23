/****************************************************
  文件：LogFactory.cs
  作者：聪头
  邮箱：1322080797@qq.com
  日期：2023/11/22 16:39:20
  功能：Nothing
*****************************************************/

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ZeroFramework
{
    public enum LogEnum
    {
        MixUnityAndLog4,
        UnityLog,
        Log4,
        None,
    }
    
    public class LogFactory
    {
        public ILogTool Create(LogEnum logEnum, Type t)
        {
            switch (logEnum)
            {
                case LogEnum.MixUnityAndLog4:
                    return new MixLog(t);
                    break;
                case LogEnum.UnityLog:
                    return new UnityLog();
                case LogEnum.Log4:
                    return new Log4net(t);
                case LogEnum.None:
                    return new NoneLog();
            }
            return null;
        }
    }
}
