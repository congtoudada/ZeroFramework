/****************************************************
  文件：EventExample.cs
  作者：聪头
  邮箱：1322080797@qq.com
  日期：2023/12/28 22:14:50
  功能：
*****************************************************/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ZeroFramework
{
    struct EventExampleStruct
    {
        public string str;
    }
    public class EventExample : MonoBehaviour
    {
        // Start is called before the first frame update
        void Start()
        {
            TypeEventKit eventKit = new TypeEventKit();
            eventKit.Register<EventExampleStruct>(data => Debug.Log(data.str));
            EventExampleStruct data = new EventExampleStruct();
            data.str = "hello world";
            eventKit.Send(data);
            eventKit.UnRegister<EventExampleStruct>();
            eventKit.Send(data);
            Debug.Log(typeof(EventExampleStruct).Name);
        }

        // Update is called once per frame
        void Update()
        {
        
        }
    }
}
