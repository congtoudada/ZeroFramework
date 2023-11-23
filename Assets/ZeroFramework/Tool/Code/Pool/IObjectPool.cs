/****************************************************
  文件：IPoolTool.cs
  作者：聪头
  邮箱：1322080797@qq.com
  日期：2023/11/23 19:58:57
  功能：Nothing
*****************************************************/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ZeroFramework
{
    public interface IObjectPool<T>
    {
        T Get();

        void Release(T obj);

        void Clear();

        int GetCountActive();

        int GetCountAll();

        int GetCountInactive();
    }
}
