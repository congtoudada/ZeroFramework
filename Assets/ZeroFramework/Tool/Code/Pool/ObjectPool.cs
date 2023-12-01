/****************************************************
  文件：PoolTool.cs
  作者：聪头
  邮箱：1322080797@qq.com
  日期：2023/11/23 19:46:51
  功能：实现参考https://docs.unity.cn/cn/2021.3/ScriptReference/Pool.ObjectPool_1.html
        Unity2021.3之后才提供对象池功能，该对象池与官方实现基本一致
        * 官方对象池的CountActive：由对象池创建且正在使用，没有归还对象池的数量
        （经实测，一旦Release时缓存池满了导致对象被删除，不会影响Active值，这会导致Active值无限上涨）
        * ZeroFramework的CountActive：只要调用Release，不论是否归还都会减少Active值
        （这种Active值比较符合直觉，表述了当前真正在使用的对象数量，而不包含失败归还被销毁的数量）
*****************************************************/

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Object = System.Object;

namespace ZeroFramework
{
    public class ObjectPool<T> : IObjectPool<T>
    {
        public int CountActive;
        public int CountAll => CountActive + CountInactive;
        public int CountInactive;

        private Stack<T> _pool;
        private Func<T> _createFunc;
        private Action<T> _actionOnGet;
        private Action<T> _actionOnRelease;
        private Action<T> _actionOnDestroy;
        private bool _collectionCheck; //如果对象已经在Pool中，是否抛出异常
        private int _defaultCapacity;
        private int _maxSize;


        public ObjectPool(Func<T> createFunc, Action<T> actionOnGet, Action<T> actionOnRelease, Action<T> actionOnDestroy,
            bool collectionCheck, int defaultCapacity, int maxSize)
        {
            _createFunc = createFunc;
            _actionOnGet = actionOnGet;
            _actionOnRelease = actionOnRelease;
            _actionOnDestroy = actionOnDestroy;
            _collectionCheck = collectionCheck;
            _defaultCapacity = defaultCapacity;
            _maxSize = maxSize;

            _pool = new Stack<T>(defaultCapacity);

            CountActive = 0;
            CountInactive = 0;
        }

        public T Get()
        {
            // 缓存池数量充足
            if (CountInactive > 0)
            {
                CountActive += 1;
                CountInactive -= 1;
                T obj = _pool.Pop();
                _actionOnGet(obj);
                return obj;
            }
            else //缓存池数量不足则生成对象返回
            {
                T obj = _createFunc();
                _actionOnGet(obj);
                CountActive += 1;
                return obj;
            }
        }

        public void Release(T obj)
        {
            // 缓存池有Get对象，才可以返回
            if (CountActive > 0)
            {
                #if UNITY_EDITOR
                //重复检验: 如果缓存池存在该对象则无法放回
                if (_collectionCheck)
                {
                    foreach (var item in _pool)
                    {
                        if (ReferenceEquals(obj, item))
                        {
                            throw new PoolObjExistException("该对象已经在对象池中，放回失败！请不要继续使用该对象！");
                        }
                    }
                }
                #endif
                
                //缓存池容量已达到上限，触发销毁事件，不放回
                if (_pool.Count >= _maxSize)
                {
                    CountActive -= 1;
                    _actionOnDestroy(obj);
                }
                else
                {
                    CountActive -= 1;
                    CountInactive += 1;
                    _actionOnRelease(obj);
                    _pool.Push(obj);
                }
            }
        }

        public void Clear()
        {
            foreach (var obj in _pool)
            {
                _actionOnDestroy(obj);
            }
            _pool.Clear();
            _pool = new Stack<T>(_defaultCapacity);
            // CountActive = 0;
            CountInactive = 0;
        }

        public int GetCountActive()
        {
            return CountActive;
        }

        public int GetCountAll()
        {
            return CountAll;
        }

        public int GetCountInactive()
        {
            return CountInactive;
        }
    }

    // public class ConcurrentPoolTool<T>
    // {
    //     
    // }
}
