/****************************************************
  文件：JsonTool.cs
  作者：聪头
  邮箱：1322080797@qq.com
  日期：2023/12/27 19:51:22
  功能：
*****************************************************/
using Newtonsoft.Json;

namespace ZeroFramework
{
    public class JsonTool
    {
        public string SerializeObject(object obj)
        {
            #if ZERO_RELEASE
            return JsonConvert.SerializeObject(obj);
            #else
            return JsonConvert.SerializeObject(obj, Formatting.Indented);
            #endif
        }

        public T DeserializeObject<T>(string json)
        {
            return JsonConvert.DeserializeObject<T>(json);
        }
    }
}