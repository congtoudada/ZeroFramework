/****************************************************
  文件：StrEventSystem.cs
  作者：聪头
  邮箱：1322080797@qq.com
  日期：2023-11-29 21:21:31
  功能：Nothing
*****************************************************/
using System;
using System.Collections.Generic;

namespace ZeroFramework
{
    public class StrEventSystem
    {
        class StrEventContainer
        {
            // key:字符串
            private Dictionary<string, IEasyEvent> mEasyEvents = new Dictionary<string, IEasyEvent>();
    
            public void AddEvent<T>(string key) where T : IEasyEvent, new() => mEasyEvents.Add(key, new T());
    
            public T GetEvent<T>(string key) where T : IEasyEvent
            {
                return mEasyEvents.TryGetValue(key, out var e) ? (T)e : default;
            }
    
            public T GetOrAddEvent<T>(string key) where T : IEasyEvent, new()
            {
                if (mEasyEvents.TryGetValue(key, out var e))
                {
                    return (T)e;
                }
                var t = new T();
                mEasyEvents.Add(key, t);
                return t;
            }

            public void Clear()
            {
                foreach (var item in mEasyEvents.Values)
                {
                    item.Clear();
                }
                mEasyEvents.Clear();
            }
        }
        
        private StrEventContainer mStrContainer = new StrEventContainer();

        public IUnRegister Register<T>(string key, Action<T> onEvent) => mStrContainer.GetOrAddEvent<EasyEvent<T>>(key).Register(onEvent);
        
        public void UnRegister<T>(string key, Action<T> onEvent)
        {
            var e = mStrContainer.GetEvent<EasyEvent<T>>(key);
            e?.UnRegister(onEvent);
        }
        
        public void UnRegister<T>(string key)
        {
            var e = mStrContainer.GetEvent<EasyEvent<T>>(key);
            e?.Clear();
        }
        
        public void Send<T>(string key) where T : new() => mStrContainer.GetEvent<EasyEvent<T>>(key)?.Trigger(new T());

        public void Send<T>(string key, T e) => mStrContainer.GetEvent<EasyEvent<T>>(key)?.Trigger(e);

        public void Clear()
        {
            mStrContainer.Clear();
        }
    }
}