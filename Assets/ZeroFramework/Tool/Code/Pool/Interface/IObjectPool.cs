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
        /// <summary>
        /// 从对象池中获取一个对象，触发actionOnGet事件。
        /// 如果对象池为空，则调用crateFunc委托创建对象并返回；如果对象池不为空，则直接从对象池内返回。
        /// </summary>
        /// <returns>对象池返回的对象</returns>
        T Get();

        /// <summary>
        /// 将对象归还到对象池。归还后的对象应视为销毁，后续不可继续使用。
        /// 如果对象池没满，直接返回对象池，触发actionOnRelease事件；如果对象池已满，丢弃对象，触发actionOnDestroy事件。
        /// </summary>
        /// <param name="obj"></param>
        void Release(T obj);

        /// <summary>
        /// 将对象池的所有对象清空，触发actionOnDestroy事件
        /// </summary>
        void Clear();

        /// <summary>
        /// 返回池已创建但当前正在使用且尚未返回的对象数。
        /// （和官方实现略有不同，当池满后触发actionOnDestroy应将对象视为销毁，该值需-1。而官方实现没有-1）
        /// </summary>
        /// <returns></returns>
        int GetCountActive();

        /// <summary>
        /// 活动和非活动对象的总数。
        /// （CountActive + CountInactive）
        /// </summary>
        /// <returns></returns>
        int GetCountAll();

        /// <summary>
        /// 池中当前可用的对象数。
        /// </summary>
        /// <returns></returns>
        int GetCountInactive();
    }
}
