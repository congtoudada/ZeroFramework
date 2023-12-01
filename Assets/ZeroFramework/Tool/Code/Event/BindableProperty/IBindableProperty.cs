/****************************************************
  文件：IBindableProperty.cs
  作者：聪头
  邮箱：1322080797@qq.com
  日期：2023/11/29 22:37:03
  功能：Nothing
*****************************************************/

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ZeroFramework
{
    public interface IBindableProperty<T> : IEasyEvent
    {
        T Value { get; set; }
        void SetValueWithoutEvent(T newValue);
        
        IUnRegister RegisterWithInitValue(Action<T, T> action);
        void UnRegister(Action<T, T> onValueChanged);
        IUnRegister Register(Action<T, T> onValueChanged);
    }
}
