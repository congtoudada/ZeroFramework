/****************************************************
  文件：PoolTool.cs
  作者：聪头
  邮箱：1322080797@qq.com
  日期：2023/11/23 20:50:40
  功能：Nothing
*****************************************************/

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ZeroFramework
{
    public class PoolTool
    {
        public IObjectPool<T> AllocateObjectPool<T>(Func<T> createFunc, Action<T> actionOnGet,
            Action<T> actionOnRelease, Action<T> actionOnDestroy,
            bool collectionCheck, int defaultCapacity, int maxSize)
        {
            return new ObjectPool<T>(createFunc, actionOnGet, actionOnRelease, actionOnDestroy, collectionCheck,
                defaultCapacity, maxSize);
        }
    }
}
