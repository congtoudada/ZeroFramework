/****************************************************
  文件：LogKit.cs
  作者：聪头
  邮箱：1322080797@qq.com
  日期：2023/11/22 14:23:54
  功能：
*****************************************************/

using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using log4net;
using UnityEngine;

namespace ZeroFramework
{
    public class LogKit : ILogKit
    {
        private Dictionary<Type, ILogger> _cache;
        private List<Type> _whiteList;
        private ILogger _noneLog;
        private readonly int _CACHE_CAPACITY;
        private ILoggerFactory _loggerFactory;
        private bool _isEnable;

        public LogKit(ILoggerFactory factory, bool _isEnable = true, int cache_capacity = 31)
        {
            _CACHE_CAPACITY = cache_capacity;
            if (_CACHE_CAPACITY < 1)
                _cache = new Dictionary<Type, ILogger>();
            else
                _cache = new Dictionary<Type, ILogger>(_CACHE_CAPACITY);

            _noneLog = factory.Create(typeof(LogKit));
            this._loggerFactory = factory;
            this._isEnable = _isEnable;
        }
        public void SetEnable(bool _isEnable)
        {
            this._isEnable = _isEnable;
            _cache.Clear();
        }

        public void SetLoggerFactory(ILoggerFactory factory)
        {
            this._loggerFactory = factory;
        }

        public ILogger AllocateLogger(Type type)
        {
            //日志开关和安全性检查
            if (!_isEnable || type == null)
                return _noneLog;
            //白名单过滤
            if (_whiteList != null && !_whiteList.Contains(type))
                return _noneLog;
            //缓存检查
            if (_cache.ContainsKey(type))
            {
                return _cache[type];
            }

            if (_cache.Count == _CACHE_CAPACITY) _cache.Clear();
            var logger = _loggerFactory.Create(type);
            _cache.Add(type, logger);
            return logger;
        }

        public ILogger AllocateLoggerOnce(Type type)
        {
            //日志开关和安全性检查
            if (!_isEnable || type == null)
                return _noneLog;
            //白名单过滤
            if (_whiteList != null && !_whiteList.Contains(type))
                return _noneLog;
            //缓存检查
            if (_cache.ContainsKey(type))
            {
                return _cache[type];
            }
            return _loggerFactory.Create(type);
        }

        public void SetWhiteFilter(List<Type> _whiteList)
        {
            this._whiteList = _whiteList;
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

        public void DebugOnce(object message, Type type)
        {
            AllocateLoggerOnce(type).Debug(message);
        }

        public void InfoOnce(object message, Type type)
        {
            AllocateLoggerOnce(type).Info(message);
        }

        public void WarnOnce(object message, Type type)
        {
            AllocateLoggerOnce(type).Warn(message);
        }

        public void ErrorOnce(object message, Type type)
        {
            AllocateLoggerOnce(type).Error(message);
        }

        public void FatalOnce(object message, Type type)
        {
            AllocateLoggerOnce(type).Fatal(message);
        }
    }
}
