/****************************************************
  文件：IEasyEvent.cs
  作者：聪头
  邮箱：1322080797@qq.com
  日期：2023/11/29 22:27:05
  功能：Nothing
*****************************************************/

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ZeroFramework
{
  public interface IEasyEventCommon
  {
    void Clear();

    int GetInvocationList();
  }
  
  public interface IEasyEvent : IEasyEventCommon
  {
    IUnRegister Register(Action onEvent);

    void UnRegister(Action onEvent);

    void Trigger();
  }
  
  public interface IEasyEvent<T> : IEasyEventCommon
  {
    IUnRegister Register(Action<T> onEvent);
    
    void UnRegister(Action<T> onEvent);

    void Trigger(T param);
  }

  public interface IEasyEvent<T, TR> : IEasyEventCommon
  {
  IUnRegister Register(Func<T, TR> onEvent);

  void UnRegister(Func<T, TR> onEvent);

  TR Trigger(T param);
  }
}
