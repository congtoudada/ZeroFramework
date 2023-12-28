/****************************************************
  文件：TypeNameEventKit.cs
  作者：聪头
  邮箱：1322080797@qq.com
  日期：2023-12-28 22:38:11
  功能：
*****************************************************/

using System;
using System.Collections.Generic;

namespace ZeroFramework
{
    public class TypeNameEventKit
    {
        private Dictionary<string, IEasyEventCommon> _typeContainer = new();
        
        public IUnRegister Register<T>(Action<T> onEvent)
        {
            string t = typeof(T).Name;
            if (_typeContainer.ContainsKey(t))
            {
                if (_typeContainer[t] is IEasyEvent<T> easyEvent)
                {
                    easyEvent.Register(onEvent);
                }
            }
            else
            {
                IEasyEvent<T> easyEvent = new EasyEvent<T>();
                _typeContainer.Add(t, easyEvent);
                easyEvent.Register(onEvent);
            }
            var unregister = new UnRegisterHandler(() => { UnRegister(onEvent); });
            return unregister;
        }

        public void UnRegister<T>(Action<T> onEvent)
        {
            string t = typeof(T).Name;
            if (_typeContainer.ContainsKey(t))
            {
                if (_typeContainer[t] is IEasyEvent<T> easyEvent)
                {
                    easyEvent.UnRegister(onEvent);
                    if (easyEvent.GetInvocationList() == 0)
                    {
                        easyEvent.Clear();
                        _typeContainer.Remove(t);
                    }
                }
            }
        }

        public void UnRegister<T>()
        {
            string t = typeof(T).Name;
            if (_typeContainer.ContainsKey(t))
            {
                _typeContainer[t].Clear();
                _typeContainer.Remove(t);
            }
        }

        public void Send<T>() where T : new()
        {
            string t = typeof(T).Name;
            if (_typeContainer.ContainsKey(t))
            {
                if (_typeContainer[t] is IEasyEvent<T> easyEvent)
                {
                    easyEvent.Trigger(new T());
                }
            }
        }

        public void Send<T>(T e)
        {
            string t = typeof(T).Name;
            if (_typeContainer.ContainsKey(t))
            {
                if (_typeContainer[t] is IEasyEvent<T> easyEvent)
                {
                    easyEvent.Trigger(e);
                }
            }
        }

        public void Clear()
        {
            _typeContainer.Clear();
            _typeContainer = new Dictionary<string, IEasyEventCommon>();
        }
    }
}