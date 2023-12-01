/****************************************************
  文件：TimestampExample.cs
  作者：聪头
  邮箱：1322080797@qq.com
  日期：2023/11/27 12:22:22
  功能：Nothing
*****************************************************/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ZeroFramework
{
    public class TimerExample : ZeroMonoController<TimerExample>
    {
        // Start is called before the first frame update
        void Start()
        {
            var timerKit = this.GetZeroToolKits().TimerKit;
            
            for (int i = 0; i < 3; i++)
            {
                timerKit.ClockTool.Tic();
                long timestamp = timerKit.TimestampTool.GetTimestamp();
                Debug.Log("Timestamp: " + timestamp);
                Debug.Log("TimeString: " + timerKit.TimestampTool.GetTimeString(timestamp));
                timerKit.ClockTool.Toc();
            }
            
            Debug.Log("---------- TimerClockTool ----------");
            Debug.Log("平均耗时: " + timerKit.ClockTool.GetAverageTime() + " ms");
            Debug.Log("第一轮耗时: " + timerKit.ClockTool.GetFirstTime() + " ms"); //若测试循环，第一轮通常Miss Cache，用时较长
            Debug.Log("最近一轮耗时: " + timerKit.ClockTool.GetCurrentTime() + " ms");
            Debug.Log("总用时: " + timerKit.ClockTool.GetTotalTime() + " ms");
            Debug.Log("总轮数: " + timerKit.ClockTool.GetCount() + " ms");
            
            timerKit.ClockTool.Clear();
            Debug.Log("清空计时器");
            Debug.Log("平均耗时: " + timerKit.ClockTool.GetAverageTime() + " ms");
        }
    }
}
