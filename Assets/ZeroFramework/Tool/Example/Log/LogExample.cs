/****************************************************
  文件：LogExample.cs
  作者：聪头
  邮箱：1322080797@qq.com
  日期：2023/11/22 14:14:58
  功能：Nothing
*****************************************************/
using System;
using System.Collections;
using System.Collections.Generic;
using log4net;
using UnityEditor;
using UnityEngine;
using ZeroFramework;

public class LogExample : ZeroMonoController<LogExample>
{
    // Start is called before the first frame update
    void Start()
    {
        // 获取日志工具
        var logKit = this.GetZeroToolKits().LogKit;
        
        // 1.直接打印日志
        logKit.Debug("直接调用", typeof(LogExample));
        // 2.使用logger打印日志
        var custom_logger = logKit.AllocateLogger(typeof(LogExample));
        custom_logger.Debug("使用Logger调用");
        // 3.架构内置函数
        logger.Debug("使用ZeroMonoController调用");
        
        // 日志开关
        logKit.SetEnable(true);
        
        // 修改日志类型为Unity.Engine.Debug
        logKit.SetLogEnum(LogEnum.UnityLog);
    }

    private void OnDestroy()
    {
        AssetDatabase.Refresh();
    }
}
