/****************************************************
  文件：ZeroToolKits.cs
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
using ZeroFramework;
using Debug = UnityEngine.Debug;

namespace ZeroFramework
{
    public class ZeroToolKits : Singleton<ZeroToolKits>, IUtility
    {
        private ZeroToolKits()
        {
            
        }
        
        #region Config
        public IConfigKit _G
        {
            get
            {
                if (_g == null)
                {
                    var replaceRule = new Dictionary<string, string>()
                    {
                        { "Streaming".ToLower(), Application.streamingAssetsPath },
                        { "Persistent".ToLower(), Application.persistentDataPath },
                        { "StreamingPath".ToLower(), Application.streamingAssetsPath },
                        { "PersistentPath".ToLower(), Application.persistentDataPath },
                        { "StreamingAssetsPath".ToLower(), Application.streamingAssetsPath },
                        { "PersistentDataPath".ToLower(), Application.persistentDataPath }
                    };
                    _g = new ConfigKit(Path.Combine(Application.streamingAssetsPath, "zero", "configs", "template_utility.yaml"), replaceRule);
                    Debug.Log("[ Zero ] 全局配置: " + (_g as ConfigKit)?._G);
                }
                return _g;
            }
        }
        private IConfigKit _g;
        #endregion
        
        #region Log
        //使用ZERO_RELEASE宏可以关闭日志系统
        public ILogKit LogKit
        {
            get
            {
                if (_logKit == null)
                {
                    ILoggerFactory loggerFactory = new ZeroLogFactory(_G.Get<string>("log.log4net.config"),
                        _G.Get<string>("log.log4net.output"));
                    loggerFactory.Init();
                    #if ZERO_RELEASE || DISABLE_LOG
                        _logKit = new LogKit(loggerFactory, false);
                    #else
                        _logKit = new LogKit(loggerFactory);
                    #endif
                }
                return _logKit;
            }
        }
        private ILogKit _logKit;
        #endregion
        
        #region File
        public IFileKit FileKit
        {
            get
            {
                if (_fileKit == null)
                {
                    _fileKit = new FileKit();
                }
                return _fileKit;
            }
        }
        private IFileKit _fileKit;
        #endregion
        
        #region Pool
        public IPoolKit PoolKit
        {
            get
            {
                if (_poolKit == null)
                {
                    _poolKit = new PoolKit();
                }
                return _poolKit;
            }
        }
        private IPoolKit _poolKit;
        #endregion
        
        #region Timestamp
        public ITimestampKit TimestampKit
        {
            get
            {
                if (_timestampKit == null)
                {
                    _timestampKit = new TimestampKit();
                }
                return _timestampKit;
            }
        }
        private ITimestampKit _timestampKit;
        #endregion
        
    }
}
