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
    public interface IBindableProperty<T>
    {
        BindableProperty<T> WithComparer(Func<T, T, bool> comparer);
        T Value { get; set; }
        void SetValueWithoutEvent(T newValue);
        IUnRegister Register(Action<T, T> onValueChanged);
        IUnRegister RegisterWithInitValue(Action<T, T> action);
        void UnRegister(Action<T, T> onValueChanged);
        void Clear();
    }
}
