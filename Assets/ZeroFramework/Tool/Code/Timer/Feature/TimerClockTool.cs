/****************************************************
  文件：TimerClockTool.cs
  作者：聪头
  邮箱：1322080797@qq.com
  日期：2023/11/27 22:08:06
  功能：Nothing
*****************************************************/
using System.Collections;
using System.Collections.Generic;
using System.Runtime.ConstrainedExecution;
using UnityEngine;

namespace ZeroFramework
{
    public class TimerClockTool : ITimerClockTool
    {
        private ITimestampTool _timestampTool; //计时工具
        private long _firstTime; //第一轮耗时
        private long _startTime; //每一轮计时开始时间
        private long _endTime; //结束耗时
        private long _totalTime; //总用时
        private int _count; //轮数

        public TimerClockTool(ITimestampTool timestampTool)
        {
            _timestampTool = timestampTool ?? new TimestampTool();
            Clear();
        }

        public long GetTotalTime()
        {
            return _totalTime;
        }

        public double GetAverageTime()
        {
            if (_count == 0) return 0;
            return (double) _totalTime / _count;
        }

        public long GetFirstTime()
        {
            return _firstTime;
        }

        public long GetCurrentTime()
        {
            return _endTime - _startTime;
        }

        public int GetCount()
        {
            return _count;
        }

        public void Tic()
        {
            _startTime = _timestampTool.GetTimestamp();
        }

        public void Toc()
        {
            _endTime = _timestampTool.GetTimestamp();
            _totalTime += (_endTime - _startTime);
            if (_firstTime == 0)
                _firstTime = _totalTime;
            _count++;
        }

        public void Clear()
        {
            _firstTime = 0; //第一轮耗时
            _startTime = 0; //每一轮计时开始时间
            _endTime = 0; //结束耗时
            _totalTime = 0; //总用时
            _count = 0; //轮数
        }
    }
}
