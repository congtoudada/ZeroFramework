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
using UnityEngine;
using ZeroFramework;

public class LogExample : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        // 1.直接打印日志
        ZeroTool.Log.Debug("直接调用", typeof(LogExample));
        // 2.使用logger打印日志
        var logger = ZeroTool.Log.AllocateLogger(typeof(LogExample));
        logger.Debug("使用Logger调用");
        
        // 日志开关
        ZeroTool.Log.SetEnable(true);
        
        // 修改日志类型为Unity.Engine.Debug
        ZeroTool.Log.SetLogEnum(LogEnum.UnityLog);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnDestroy()
    {

    }
}
