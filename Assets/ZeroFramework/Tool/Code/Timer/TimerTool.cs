/****************************************************
  文件：TimerTool.cs
  作者：聪头
  邮箱：1322080797@qq.com
  日期：2023/11/27 12:24:09
  功能：Nothing
*****************************************************/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ZeroFramework
{
    public class TimerTool : ITimerTool
    {
        private ITimestampTool Timestamp
        {
            get
            {
                if (_timestampTool == null)
                {
                    _timestampTool = new TimestampTool();
                }

                return _timestampTool;
            }
        }
        private ITimestampTool _timestampTool;
        
        private ITimerClockTool TimerClock
        {
            get
            {
                if (_timerClockTool == null)
                {
                    _timerClockTool = new TimerClockTool(Timestamp);
                }

                return _timerClockTool;
            }
        }
        private ITimerClockTool _timerClockTool;


        public ITimestampTool TimestampTool => Timestamp;
        public ITimerClockTool ClockTool => TimerClock;
    }
}
