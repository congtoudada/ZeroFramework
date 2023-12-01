/****************************************************
  文件：IEasyEvent.cs
  作者：聪头
  邮箱：1322080797@qq.com
  日期：2023/11/29 17:09:51
  功能：Nothing
*****************************************************/

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ZeroFramework
{
    public class EasyEvent : IEasyEvent
    {
        private Action mOnEvent;

        public IUnRegister Register(Action onEvent)
        {
            mOnEvent += onEvent;
            return new UnRegisterHandler(() => { UnRegister(onEvent); });
        }

        public void UnRegister(Action onEvent) => mOnEvent -= onEvent;

        public void Trigger() => mOnEvent?.Invoke();
        
        public void Clear()
        {
            mOnEvent = null;
        }
    }

    public class EasyEvent<T> : IEasyEvent
    {
        private Action<T> mOnEvent;

        public IUnRegister Register(Action<T> onEvent)
        {
            mOnEvent += onEvent;
            return new UnRegisterHandler(() => { UnRegister(onEvent); });
        }

        public void UnRegister(Action<T> onEvent) => mOnEvent -= onEvent;

        public void Trigger(T t) => mOnEvent?.Invoke(t);
        
        // 本质还是只能注册无参调用事件
        IUnRegister IEasyEvent.Register(Action onEvent)
        {
            void Action(T _) => onEvent();
            return Register(Action);
        }
        
        public void Clear()
        {
            mOnEvent = null;
        }
    }
    
    public class EasyEvent<T, K> : IEasyEvent
    {
        private Action<T, K> mOnEvent;

        public IUnRegister Register(Action<T, K> onEvent)
        {
            mOnEvent += onEvent;
            return new UnRegisterHandler(() => { UnRegister(onEvent); });
        }

        public void UnRegister(Action<T, K> onEvent) => mOnEvent -= onEvent;

        public void Trigger(T t, K k) => mOnEvent?.Invoke(t,k);
        
        public IUnRegister Register(Action onEvent)
        {
            void Action(T _, K __) => onEvent();
            return Register(Action);
        }
        
        public void Clear()
        {
            mOnEvent = null;
        }
    }
}
