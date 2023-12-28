/****************************************************
  文件：ITypeEventKit.cs
  作者：聪头
  邮箱：1322080797@qq.com
  日期：2023-12-28 20:21:36
  功能：
*****************************************************/

using System;

namespace ZeroFramework
{
    public interface ITypeEventKit : IUtility
    {
        IUnRegister Register<T>(Action<T> onEvent);

        void UnRegister<T>(Action<T> onEvent);

        void UnRegister<T>();

        void Send<T>() where T : new();

        void Send<T>(T e);

        void Clear();
    }
}