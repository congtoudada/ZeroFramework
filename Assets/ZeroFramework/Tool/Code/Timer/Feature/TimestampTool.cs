/****************************************************
  文件：TimeTool.cs
  作者：聪头
  邮箱：1322080797@qq.com
  日期：2021/8/3 12:08:51
  功能：Nothing
*****************************************************/
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ZeroFramework
{
    public class TimestampTool : ITimestampTool
    {
        private readonly DateTime time1970;
        public TimestampTool()
        {
            time1970 = new DateTime(1970, 1, 1, 0, 0, 0, 0);
        }
        ///获得时间戳 单位: ms
        public long GetTimestamp(bool isMilliseconds = true)
        {
            TimeSpan ts = DateTime.UtcNow - time1970;
            if(isMilliseconds)
                return Convert.ToInt64(ts.TotalMilliseconds);
            else
                return Convert.ToInt64(ts.TotalSeconds);
        }
        
        //根据时间戳获得日期字符串(1999-11-01 18:00:00) 单位:ms
        public string GetTimeString(long millionSeconds, string format = "yyyy-MM-dd HH:mm:ss")
        {
            return time1970.AddMilliseconds(millionSeconds).AddHours(8).ToString(format);
        }
    }
}
