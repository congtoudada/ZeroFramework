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

        public int GetInvocationList()
        {
            return mOnEvent.GetInvocationList().Length;
        }
    }
    public class EasyEvent<T> : IEasyEvent<T>
    {
        private Action<T> mOnEvent;

        public IUnRegister Register(Action<T> onEvent)
        {
            mOnEvent += onEvent;
            return new UnRegisterHandler(() => { UnRegister(onEvent); });
        }

        public void UnRegister(Action<T> onEvent) => mOnEvent -= onEvent;

        public void Trigger(T t) => mOnEvent?.Invoke(t);

        public void Clear()
        {
            mOnEvent = null;
        }
        
        public int GetInvocationList()
        {
            return mOnEvent.GetInvocationList().Length;
        }
    }
    
    public class EasyEvent<T, TR> : IEasyEvent<T, TR>
    {
        private Func<T, TR> mOnEvent;

        public IUnRegister Register(Func<T, TR> onEvent)
        {
            mOnEvent += onEvent;
            return new UnRegisterHandler(() => { UnRegister(onEvent); });
        }

        public void UnRegister(Func<T, TR> onEvent) => mOnEvent -= onEvent;

        public TR Trigger(T t)
        {
            if (mOnEvent != null)
            {
                return mOnEvent.Invoke(t);
            }
            return default(TR);
        }
        
        public void Clear()
        {
            mOnEvent = null;
        }
        
        public int GetInvocationList()
        {
            return mOnEvent.GetInvocationList().Length;
        }
    }
}
