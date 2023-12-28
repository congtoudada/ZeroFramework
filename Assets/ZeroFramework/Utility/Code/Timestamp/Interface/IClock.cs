/****************************************************
  文件：IClock.cs
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
    public interface IClock
    {
        long GetTotalUseTime();
        
        double GetAverageUseTime();

        long GetFirstUseTime();

        long GetCurrentUseTime();

        int GetCount();

        void Tic();

        void Toc();
        
        void Reset();
    }
}
