/****************************************************
  文件：ZeroLogFactory.cs
  作者：聪头
  邮箱：1322080797@qq.com
  日期：2023/12/27 19:51:22
  功能：
*****************************************************/

using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

namespace ZeroFramework
{
    public class ZeroLogFactory : ILoggerFactory
    {
        private readonly string _configPath;
        private readonly string _outputPath;
        public ZeroLogFactory(string configPath, string outputPath)
        {
            _configPath = configPath;
            _outputPath = outputPath;
        }
        
        public void Init()
        {
            try
            {
                Log4net.Init(_configPath, _outputPath);
            }
            catch (Exception e)
            {
                Debug.LogError(e.StackTrace);
            }
        }

        public ILogger Create(Type type)
        {
            return new MixLog(type);
        }
    }
}
