/****************************************************
  文件：EnumEventSystem.cs
  作者：聪头
  邮箱：1322080797@qq.com
  日期：2023-11-29 21:20:58
  功能：Nothing
*****************************************************/
using System;
using System.Collections.Generic;

namespace ZeroFramework
{
    public class EnumEventSystem
    {
        class EnumEventContainer
        {
            // key:字符串
            private Dictionary<Enum, IEasyEvent> mEasyEvents = new Dictionary<Enum, IEasyEvent>();
    
            public void AddEvent<T>(Enum key) where T : IEasyEvent, new() => mEasyEvents.Add(key, new T());
    
            public T GetEvent<T>(Enum key) where T : IEasyEvent
            {
                return mEasyEvents.TryGetValue(key, out var e) ? (T)e : default;
            }
    
            public T GetOrAddEvent<T>(Enum key) where T : IEasyEvent, new()
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
        
        private EnumEventContainer mEnumContainer = new EnumEventContainer();

        public IUnRegister Register<T>(Enum key, Action<T> onEvent) => mEnumContainer.GetOrAddEvent<EasyEvent<T>>(key).Register(onEvent);
        
        public void UnRegister<T>(Enum key, Action<T> onEvent)
        {
            var e = mEnumContainer.GetEvent<EasyEvent<T>>(key);
            e?.UnRegister(onEvent);
        }
        
        public void UnRegister<T>(Enum key)
        {
            var e = mEnumContainer.GetEvent<EasyEvent<T>>(key);
            e?.Clear();
        }
        
        public void Send<T>(Enum key) where T : new() => mEnumContainer.GetEvent<EasyEvent<T>>(key)?.Trigger(new T());

        public void Send<T>(Enum key, T e) => mEnumContainer.GetEvent<EasyEvent<T>>(key)?.Trigger(e);

        public void Clear()
        {
            mEnumContainer.Clear();
        }
    }
}