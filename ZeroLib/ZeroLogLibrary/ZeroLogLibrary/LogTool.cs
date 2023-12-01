/****************************************************
  文件：LogTool.cs
  作者：聪头
  邮箱：1322080797@qq.com
  日期：2023/11/22 14:23:54
  功能：Nothing
*****************************************************/

using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using log4net;
using UnityEngine;

namespace ZeroFramework
{
    public class LogTool : ILogTool
    {
        private Dictionary<Type, ILogToolFeature> _cache;
        private const int _CACHE_CAPACITY = 15;
        private LogFactory _logFactory;
        private LogEnum _defaultLogEnum;
        private bool is_enable;
        private ILogToolFeature noneLog;

        public LogTool(LogEnum logEnum, bool is_enable)
        {
            _logFactory = new LogFactory();
            _defaultLogEnum = logEnum;
            this.is_enable = is_enable;
        }

        public void SetLogEnum(LogEnum logEnum)
        {
            _defaultLogEnum = logEnum;
        }
        public void SetEnable(bool is_enable)
        {
            this.is_enable = is_enable;
        }

        public ILogToolFeature AllocateLogger(Type type)
        {
            if (!is_enable || type==null)
            {
                if (noneLog == null)
                    noneLog = _logFactory.Create(LogEnum.None, null);
                return noneLog;
            }

            if (_cache == null)
                _cache = new Dictionary<Type, ILogToolFeature>(_CACHE_CAPACITY);
            
            if (_cache.ContainsKey(type))
            {
                return _cache[type];
            }

            if (_cache.Count == _CACHE_CAPACITY) _cache.Clear();
            var logger = _logFactory.Create(_defaultLogEnum, type);
            _cache.Add(type, logger);
            return logger;
        }

        public void Debug(object message, Type type)
        {
            AllocateLogger(type).Debug(message);
        }

        public void Info(object message, Type type)
        {
            AllocateLogger(type).Info(message);
        }

        public void Warn(object message, Type type)
        {
            AllocateLogger(type).Warn(message);
        }

        public void Error(object message, Type type)
        {
            AllocateLogger(type).Error(message);
        }

        public void Fatal(object message, Type type)
        {
            AllocateLogger(type).Fatal(message);
        }
    }
}
