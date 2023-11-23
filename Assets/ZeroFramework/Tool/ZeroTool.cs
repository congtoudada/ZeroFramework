/****************************************************
  文件：ZeroTool.cs
  作者：聪头
  邮箱：1322080797@qq.com
  日期：2023/11/22 14:25:26
  功能：打包时建议使用 [ZERO_RELEASE] 
*****************************************************/
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using log4net;
using UnityEngine;
using Debug = UnityEngine.Debug;

namespace ZeroFramework
{
    public class ZeroTool
    {
        #region Log
        //使用ZERO_RELEASE宏可以关闭日志系统
        public static LogTool Log
        {
            get
            {
                if (_logTool == null)
                {
                    #if ZERO_RELEASE || DISABLE_LOG
                        _logTool = new LogTool(LogEnum.UnityLog, false);
                    #else
                        GlobalContext.Properties["ApplicationLogPath"] = Path.Combine(Application.streamingAssetsPath, "log");
                        _logTool = new LogTool(LogEnum.MixUnityAndLog4, true);
                    #endif
                }
                return _logTool;
            }
        }
        private static LogTool _logTool;
        #endregion
        
        #region Pool
        public static PoolTool Pool
        {
            get
            {
                if (_poolTool == null)
                {
                    _poolTool = new PoolTool();
                }
                return _poolTool;
            }
        }
        private static PoolTool _poolTool;
        #endregion
    }
}
