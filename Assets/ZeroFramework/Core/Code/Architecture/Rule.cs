/****************************************************
  文件：Rule.cs
  作者：聪头
  邮箱：1322080797@qq.com
  日期：2023/11/29 16:04:15
  功能：定义架构接口规则
*****************************************************/

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ZeroFramework
{
  public interface IBelongToArchitecture
  {
    IArchitecture GetArchitecture();
  }
  
  public interface ICanSetArchitecture
  {
    void SetArchitecture(IArchitecture architecture);
  }
  
  public interface ICanGetModel : IBelongToArchitecture
  { }
  
  public static class CanGetModelExtension
  {
    public static T GetModel<T>(this ICanGetModel self) where T : class, IModel =>
      self.GetArchitecture().GetModel<T>();
  }
  
  public interface ICanGetSystem : IBelongToArchitecture
  { }
  
  public static class CanGetSystemExtension
  {
    public static T GetSystem<T>(this ICanGetSystem self) where T : class, ISystem =>
      self.GetArchitecture().GetSystem<T>();
  }
  
  public interface ICanGetUtility : IBelongToArchitecture
  { }
  
  public static class CanGetUtilityExtension
  {
    public static T GetUtility<T>(this ICanGetUtility self) where T : class, IUtility =>
      self.GetArchitecture().GetUtility<T>();
  }
  
  public interface ICanRegisterEvent : IBelongToArchitecture
  { }
  
  public static class CanRegisterEventExtension
  {
    public static IUnRegister RegisterEvent<T>(this ICanRegisterEvent self, Action<T> onEvent) =>
      self.GetArchitecture().RegisterEvent<T>(onEvent);

    public static void UnRegisterEvent<T>(this ICanRegisterEvent self, Action<T> onEvent) =>
      self.GetArchitecture().UnRegisterEvent<T>(onEvent);
    
    public static void UnRegisterEvent<T>(this ICanRegisterEvent self) =>
      self.GetArchitecture().UnRegisterEvent<T>();
  }
  
  public interface ICanSendEvent : IBelongToArchitecture
  { }
  
  public static class CanSendEventExtension
  {
    public static void SendEvent<T>(this ICanSendEvent self) where T : new() =>
      self.GetArchitecture().SendEvent<T>();

    public static void SendEvent<T>(this ICanSendEvent self, T e) => self.GetArchitecture().SendEvent<T>(e);
  }
  
  public interface ICanSendCommand : IBelongToArchitecture
  { }
  
  public static class CanSendCommandExtension
  {
    public static void SendCommand<T>(this ICanSendCommand self) where T : ICommand, new() =>
      self.GetArchitecture().SendCommand<T>(new T());

    public static void SendCommand<T>(this ICanSendCommand self, T command) where T : ICommand =>
      self.GetArchitecture().SendCommand<T>(command);

    public static TResult SendCommand<TResult>(this ICanSendCommand self, ICommand<TResult> command) =>
      self.GetArchitecture().SendCommand(command);
  }

  public interface ICanSendQuery : IBelongToArchitecture
  { }
  
  public static class CanSendQueryExtension
  {
    public static TResult SendQuery<TResult>(this ICanSendQuery self, IQuery<TResult> query) =>
      self.GetArchitecture().SendQuery(query);
  }
  
  public interface ICanInit
  {
    bool Initialized { get; set; }
    void Init();
    void Deinit();
  }
}
