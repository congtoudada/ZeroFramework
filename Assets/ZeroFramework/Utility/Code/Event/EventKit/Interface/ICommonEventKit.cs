/****************************************************
  文件：ICommonEventKit.cs
  作者：聪头
  邮箱：1322080797@qq.com
  日期：2023-12-28 21:14:17
  功能：
*****************************************************/

using System;

namespace ZeroFramework
{
    public interface ICommonEventKit<TKey> : IUtility
    {
        IUnRegister Register<T>(TKey key, Action<T> onEvent);

        void UnRegister<T>(TKey key, Action<T> onEvent);

        void UnRegister(TKey key);

        void Send<T>(TKey key) where T : new();

        void Send<T>(TKey key, T e);

        void Clear();
    }
}