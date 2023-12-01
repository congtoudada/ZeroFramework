/****************************************************
  文件：ITimerTool.cs
  作者：聪头
  邮箱：1322080797@qq.com
  日期：2023/11/27 12:24:58
  功能：Nothing
*****************************************************/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ZeroFramework
{
    public interface ITimerTool
    {
        ITimestampTool TimestampTool { get; }

        ITimerClockTool ClockTool { get; }
    }
}
