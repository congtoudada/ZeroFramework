/****************************************************
  文件：SimpleObjectPool.cs
  作者：聪头
  邮箱：1322080797@qq.com
  日期：2023-12-28 16:10:07
  功能：
*****************************************************/

using System;

namespace ZeroFramework
{
    public class SimpleObjectPool<T> : ObjectPool<T>
    {
        public SimpleObjectPool(Func<T> createFunc, Action<T> actionOnGet, Action<T> actionOnRelease, 
            Action<T> actionOnDestroy, bool collectionCheck, int defaultCapacity, int maxSize, bool isPreLoad)
            : base(createFunc, actionOnGet, actionOnRelease, actionOnDestroy, collectionCheck, defaultCapacity, maxSize, isPreLoad)
        {
            
        }
    }
}