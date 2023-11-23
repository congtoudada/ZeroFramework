/****************************************************
  文件：Log4net.cs
  作者：聪头
  邮箱：1322080797@qq.com
  日期：2023/11/22 14:14:58
  功能：Nothing
*****************************************************/
using System;
using System.Diagnostics;
using System.IO;
using log4net;
using log4net.Appender;
using log4net.Config;
using log4net.Repository;
using UnityEngine;

namespace ZeroFramework
{
    public class Log4net : ILogTool
    {
        private ILog _logger;
        private Type t;
        
        // 获取调用LogWithStackTrace方法的堆栈信息
        private static StackTrace stackTrace;

        static Log4net()
        {
            FileInfo file = new System.IO.FileInfo(Application.streamingAssetsPath + "/zero_configs/log4net.config"); //获取log4net配置文件
            //GlobalContext.Properties["ApplicationLogPath"] = Path.Combine(Application.streamingAssetsPath, "log");
            XmlConfigurator.ConfigureAndWatch(file); //加载log4net配置文件
            Application.quitting += () =>
            {
                LogManager.ShutdownRepository();
                LogManager.Shutdown();
            };
            //UnityEngine.Debug.Log("---------- Log4net全局初始化完成 ----------");
        }

        public Log4net(Type t)
        {
            this.t = t;
            _logger = LogManager.GetLogger(t);
        }

        private string ProcessMessage(object message)
        {
            // 获取调用LogWithStackTrace方法的堆栈信息
            StackTrace stackTrace = new StackTrace(true);
            return $"{t.Name}:{stackTrace.GetFrame(stackTrace.FrameCount-1).GetFileLineNumber()} - {message}";
        }

        public void Debug(object message)
        {
            _logger.Debug(ProcessMessage(message));
        }

        public void Info(object message)
        {
            _logger.Info(ProcessMessage(message));
        }

        public void Warn(object message)
        {
            _logger.Warn(ProcessMessage(message));
        }

        public void Error(object message)
        {
            _logger.Error(ProcessMessage(message));
        }

        public void Fatal(object message)
        {
            _logger.Fatal(ProcessMessage(message));
        }
    }
}
