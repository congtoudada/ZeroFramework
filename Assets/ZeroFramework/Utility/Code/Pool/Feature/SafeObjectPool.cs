/****************************************************
  文件：SafeObjectPool.cs
  作者：聪头
  邮箱：1322080797@qq.com
  日期：2023-12-28 16:10:19
  功能：
*****************************************************/

using System;

namespace ZeroFramework
{
    public class SafeObjectPool<T> : ObjectPool<T>
    {
        public SafeObjectPool(Func<T> createFunc, Action<T> actionOnGet, Action<T> actionOnRelease, 
            Action<T> actionOnDestroy, bool collectionCheck, int maxSize) 
            : base(createFunc, actionOnGet, actionOnRelease, actionOnDestroy, collectionCheck, maxSize, maxSize, true)
        {
        }

        public override T Get()
        {
            // 缓存池数量充足
            if (CountInactive > 0)
            {
                CountActive += 1;
                CountInactive -= 1;
                T obj = _pool.Pop();
                _actionOnGet?.Invoke(obj);
                return obj;
            }
            return default(T);
        }
    }
}