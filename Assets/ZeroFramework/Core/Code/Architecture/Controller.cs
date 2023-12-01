/****************************************************
  文件：Controller.cs
  作者：聪头
  邮箱：1322080797@qq.com
  日期：2023/11/29 21:36:45
  功能：Nothing
*****************************************************/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ZeroFramework
{
  public interface IController : IBelongToArchitecture, ICanSendCommand, ICanGetSystem, ICanGetModel,
    ICanRegisterEvent, ICanSendQuery, ICanGetUtility
  { }
}
