/****************************************************
  文件：ZeroArchitecture.cs
  作者：聪头
  邮箱：1322080797@qq.com
  日期：2023/11/30 16:49:20
  功能：Nothing
*****************************************************/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ZeroFramework
{
    public class ZeroArchitecture : Architecture<ZeroArchitecture>
    {
        protected override void Init()
        {
            // RegisterUtility(new ZeroToolKits());
            RegisterUtility<ZeroToolKits>(() => new ZeroToolKits());
        }
    }
}
