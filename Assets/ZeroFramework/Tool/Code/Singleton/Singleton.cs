/****************************************************
  文件：Singleton.cs
  作者：聪头
  邮箱：1322080797@qq.com
  日期：2021/11/10 22:47:13
  功能：单例模式基类
*****************************************************/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ZeroFramework
{
    //全局单例（懒加载）
    public class Singleton<T> where T : new()
    {
        private static T _instance;
        public static T Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new T();
                }
                return _instance;
            }
        }

        protected Singleton()
        {
            Init();
        }
        
        protected virtual void Init(){ }
    }
}
