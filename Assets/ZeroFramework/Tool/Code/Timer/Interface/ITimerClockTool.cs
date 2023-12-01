/****************************************************
  文件：ITimerClockTool.cs
  作者：聪头
  邮箱：1322080797@qq.com
  日期：2023/11/27 22:08:17
  功能：Nothing
*****************************************************/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ZeroFramework
{
    public interface ITimerClockTool
    {
        /// <summary>
        /// 得到总耗时 ms
        /// </summary>
        /// <returns></returns>
        long GetTotalTime();
        
        /// <summary>
        /// 得到平均耗时 ms
        /// </summary>
        /// <returns></returns>
        double GetAverageTime();

        /// <summary>
        /// 得到第一轮耗时 ms
        /// </summary>
        /// <returns></returns>
        long GetFirstTime();

        /// <summary>
        /// 得到最近一轮耗时 ms
        /// </summary>
        /// <returns></returns>
        long GetCurrentTime();

        /// <summary>
        /// 调用Tic-Toc轮数
        /// </summary>
        /// <returns></returns>
        int GetCount();

        /// <summary>
        /// 开始计时
        /// </summary>
        void Tic();

        /// <summary>
        /// 结束一轮计时
        /// </summary>
        void Toc();
        
        /// <summary>
        /// 清空计时器
        /// </summary>
        void Clear();
    }
}
