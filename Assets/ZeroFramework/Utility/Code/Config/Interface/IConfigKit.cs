/****************************************************
  文件：IConfigKit.cs
  作者：聪头
  邮箱：1322080797@qq.com
  日期：2023-12-28 14:03:38
  功能: 
*****************************************************/

using Newtonsoft.Json.Linq;

namespace ZeroFramework
{
    public interface IConfigKit
    {
        JToken this[string key] { get; set; }
        
        T Get<T>(string key);
    }
}