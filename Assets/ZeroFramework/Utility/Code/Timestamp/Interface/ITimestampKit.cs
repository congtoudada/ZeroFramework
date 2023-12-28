/****************************************************
  文件：ITimestampKit.cs
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
    public interface ITimestampKit : IUtility
    {
        long GetTimestamp(bool isMilliseconds = true);

        string GetTimeString(long millionSeconds, string format = "yyyy-MM-dd HH:mm:ss");

        IClock AllocateClock();
    }
}
