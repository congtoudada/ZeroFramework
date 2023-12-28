/****************************************************
  文件：ZeroController.cs
  作者：聪头
  邮箱：1322080797@qq.com
  日期：2023-11-30 19:33:26
  功能：Nothing
*****************************************************/

using log4net;
using UnityEngine;

namespace ZeroFramework
{
    // 自主实现IZeroController，必须确保具有ZeroArchitecture.Init的内容
    public interface IZeroController : IController
    {
        
    }

    public static class ZeroControllerExtension
    {
        /// <summary>
        /// 获得内置 ZeroToolKits工具包
        /// </summary>
        /// <param name="self"></param>
        /// <returns></returns>
        public static ZeroToolKits GetZeroToolKits(this IZeroController self)
        {
            return self.GetUtility<ZeroToolKits>();
        }
    }
    
    public class ZeroMonoController<T> : MonoBehaviour, IZeroController where T : ZeroMonoController<T>
    {
        public ILogger logger
        {
            get
            {
                if (_logger == null)
                {
                    _logger = this.GetZeroToolKits().LogKit.AllocateLogger(typeof(T));
                }

                return _logger;
            }
        }
        private ILogger _logger;
        
        public IArchitecture GetArchitecture()
        {
            return ZeroArchitecture.Interface;
        }
    }
    
    public class ZeroController<T> : IZeroController where T : ZeroController<T>
    {
        public ILogger logger
        {
            get
            {
                if (_logger == null)
                {
                    _logger = this.GetZeroToolKits().LogKit.AllocateLogger(typeof(T));
                }

                return _logger;
            }
        }
        private ILogger _logger;
        
        public IArchitecture GetArchitecture()
        {
            return ZeroArchitecture.Interface;
        }
    }
}