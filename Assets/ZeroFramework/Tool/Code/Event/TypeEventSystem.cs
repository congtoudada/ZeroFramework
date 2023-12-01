/****************************************************
  文件：TypeEventSystem.cs
  作者：聪头
  邮箱：1322080797@qq.com
  日期：2023-11-29 21:22:08
  功能：Nothing
*****************************************************/
using System;
using System.Collections.Generic;

namespace ZeroFramework
{
    public class TypeEventSystem
    {
        class TypeEventContainer
        {
            // key:类型
            private Dictionary<Type, IEasyEvent> mEasyEvents = new Dictionary<Type, IEasyEvent>();
    
            public void AddEvent<T>() where T : IEasyEvent, new() => mEasyEvents.Add(typeof(T), new T());
    
            public T GetEvent<T>() where T : IEasyEvent
            {
                return mEasyEvents.TryGetValue(typeof(T), out var e) ? (T)e : default;
            }
    
            public T GetOrAddEvent<T>() where T : IEasyEvent, new()
            {
                var eType = typeof(T);
                if (mEasyEvents.TryGetValue(eType, out var e))
                {
                    return (T)e;
                }
                var t = new T();
                mEasyEvents.Add(eType, t);
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
        
        private TypeEventContainer mTypeContainer = new TypeEventContainer();

        public IUnRegister Register<T>(Action<T> onEvent) => mTypeContainer.GetOrAddEvent<EasyEvent<T>>().Register(onEvent);
        
        public void UnRegister<T>(Action<T> onEvent)
        {
            var e = mTypeContainer.GetEvent<EasyEvent<T>>();
            e?.UnRegister(onEvent);
        }
        
        public void UnRegister<T>()
        {
            var e = mTypeContainer.GetEvent<EasyEvent<T>>();
            e?.Clear();
        }
        
        public void Send<T>() where T : new() => mTypeContainer.GetEvent<EasyEvent<T>>()?.Trigger(new T());

        public void Send<T>(T e) => mTypeContainer.GetEvent<EasyEvent<T>>()?.Trigger(e);

        public void Clear()
        {
            mTypeContainer.Clear();
        }
    }
}