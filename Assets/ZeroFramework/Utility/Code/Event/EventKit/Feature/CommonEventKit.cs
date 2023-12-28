﻿/****************************************************
  文件：CommonEventKit.cs
  作者：聪头
  邮箱：1322080797@qq.com
  日期：2023-12-28 21:16:51
  功能：
*****************************************************/
using System;
using System.Collections.Generic;

namespace ZeroFramework
{
    public class CommonEventKit<TKey> : ICommonEventKit<TKey>
    {
        private Dictionary<TKey, IEasyEventCommon> _typeContainer = new();
        
        public IUnRegister Register<T>(TKey key, Action<T> onEvent)
        {
            if (_typeContainer.ContainsKey(key))
            {
                if (_typeContainer[key] is IEasyEvent<T> easyEvent)
                {
                    easyEvent.Register(onEvent);
                }
            }
            else
            {
                IEasyEvent<T> easyEvent = new EasyEvent<T>();
                _typeContainer.Add(key, easyEvent);
                easyEvent.Register(onEvent);
            }
            var unregister = new UnRegisterHandler(() => { UnRegister(key, onEvent); });
            return unregister;
        }

        public void UnRegister<T>(TKey key, Action<T> onEvent)
        {
            if (_typeContainer.ContainsKey(key))
            {
                if (_typeContainer[key] is IEasyEvent<T> easyEvent)
                {
                    easyEvent.UnRegister(onEvent);
                    if (easyEvent.GetInvocationList() == 0)
                    {
                        easyEvent.Clear();
                        _typeContainer.Remove(key);
                    }
                }
            }
        }

        public void UnRegister(TKey key)
        {
            if (_typeContainer.ContainsKey(key))
            {
                _typeContainer[key].Clear();
                _typeContainer.Remove(key);
            }
        }

        public void Send<T>(TKey key) where T : new()
        {
            if (_typeContainer.ContainsKey(key))
            {
                if (_typeContainer[key] is IEasyEvent<T> easyEvent)
                {
                    easyEvent.Trigger(new T());
                }
            }
        }

        public void Send<T>(TKey key, T e)
        {
            if (_typeContainer.ContainsKey(key))
            {
                if (_typeContainer[key] is IEasyEvent<T> easyEvent)
                {
                    easyEvent.Trigger(e);
                }
            }
        }

        public void Clear()
        {
            _typeContainer.Clear();
            _typeContainer = new Dictionary<TKey, IEasyEventCommon>();
        }
    }
}