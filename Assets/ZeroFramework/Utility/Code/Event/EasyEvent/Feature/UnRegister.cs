/****************************************************
  文件：UnRegister.cs
  作者：聪头
  邮箱：1322080797@qq.com
  日期：2023-12-28 19:21:56
  功能：
*****************************************************/

using System;
using System.Collections.Generic;
using UnityEngine;

namespace ZeroFramework
{
  public struct UnRegisterHandler : IUnRegister
  {
    private Action mOnUnRegister { get; set; }
    public UnRegisterHandler(Action onUnRegister) => mOnUnRegister = onUnRegister;

    public void UnRegister()
    {
      mOnUnRegister.Invoke();
      mOnUnRegister = null;
    }
  }
  
  public abstract class UnRegisterTrigger : MonoBehaviour
  {
    private HashSet<IUnRegister> mUnRegisters = new HashSet<IUnRegister>();
    public void AddUnRegister(IUnRegister unRegister) => mUnRegisters.Add(unRegister);

    public void RemoveUnRegister(IUnRegister unRegister) => mUnRegisters.Remove(unRegister);

    public void UnRegister()
    {
      foreach (var unRegister in mUnRegisters)
      {
        unRegister.UnRegister();
      }
      mUnRegisters.Clear();
      // mUnRegisters = null;
      // Destroy(this);
    }
  }

  public class UnRegisterOnDestroyTrigger : UnRegisterTrigger
  {
    private void OnDestroy()
    {
      UnRegister();
    }
  }

  public class UnRegisterOnDisableTrigger : UnRegisterTrigger
  {
    private void OnDisable()
    {
      UnRegister();
    }
  }

  public static class UnRegisterExtension
  {
    public static IUnRegister UnRegisterWhenGameObjectDestroyed(this IUnRegister unRegister,
      UnityEngine.GameObject gameObject)
    {
      var trigger = gameObject.GetComponent<UnRegisterOnDestroyTrigger>();

      if (!trigger)
      {
        trigger = gameObject.AddComponent<UnRegisterOnDestroyTrigger>();
      }

      trigger.AddUnRegister(unRegister);

      return unRegister;
    }

    public static IUnRegister UnRegisterWhenGameObjectDestroyed<T>(this IUnRegister self, T component)
      where T : UnityEngine.Component =>
      self.UnRegisterWhenGameObjectDestroyed(component.gameObject);

    public static IUnRegister UnRegisterWhenDisabled(this IUnRegister unRegister,
      UnityEngine.GameObject gameObject)
    {
      var trigger = gameObject.GetComponent<UnRegisterOnDisableTrigger>();

      if (!trigger)
      {
        trigger = gameObject.AddComponent<UnRegisterOnDisableTrigger>();
      }

      trigger.AddUnRegister(unRegister);

      return unRegister;
    }
    
    public static IUnRegister UnRegisterWhenDisabled<T>(this IUnRegister self, T component)
      where T : UnityEngine.Component =>
      self.UnRegisterWhenDisabled(component.gameObject);
  }
}