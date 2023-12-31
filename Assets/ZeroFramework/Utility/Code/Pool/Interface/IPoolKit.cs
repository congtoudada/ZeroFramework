﻿/****************************************************
  文件：IPoolKit.cs
  作者：聪头
  邮箱：1322080797@qq.com
  日期：2023/11/23 19:58:57
  功能：Nothing
*****************************************************/
using System;

namespace ZeroFramework
{
    public interface IPoolKit : IUtility
    {
        IObjectPool<T> AllocateSimpleObjectPool<T>(Func<T> createFunc, Action<T> actionOnGet,
            Action<T> actionOnRelease, Action<T> actionOnDestroy,
            bool collectionCheck, int defaultCapacity, int maxSize, bool isPreLoad = false);
        
        IObjectPool<T> AllocateSafeObjectPool<T>(Func<T> createFunc, Action<T> actionOnGet,
            Action<T> actionOnRelease, Action<T> actionOnDestroy,
            bool collectionCheck, int maxSize);
    }
}