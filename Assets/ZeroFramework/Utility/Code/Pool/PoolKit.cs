/****************************************************
  文件：PoolKit.cs
  作者：聪头
  邮箱：1322080797@qq.com
  日期：2023/11/23 20:50:40
  功能：
*****************************************************/

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ZeroFramework
{
    public class PoolKit : IPoolKit
    {
        public IObjectPool<T> AllocateSimpleObjectPool<T>(Func<T> createFunc, Action<T> actionOnGet, Action<T> actionOnRelease,
            Action<T> actionOnDestroy, bool collectionCheck, int defaultCapacity, int maxSize, bool isPreLoad)
        {
            return new SimpleObjectPool<T>(createFunc, actionOnGet, actionOnRelease, actionOnDestroy, collectionCheck,
                defaultCapacity, maxSize, isPreLoad);
        }

        public IObjectPool<T> AllocateSafeObjectPool<T>(Func<T> createFunc, Action<T> actionOnGet, Action<T> actionOnRelease,
            Action<T> actionOnDestroy, bool collectionCheck, int maxSize)
        {
            return new SafeObjectPool<T>(createFunc, actionOnGet, actionOnRelease, actionOnDestroy, collectionCheck, maxSize);
        }
    }
}
