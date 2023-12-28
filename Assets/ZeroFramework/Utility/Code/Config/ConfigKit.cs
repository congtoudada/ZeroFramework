/****************************************************
  文件：ConfigKit.cs
  作者：聪头
  邮箱：1322080797@qq.com
  日期：2023-12-28 14:29:42
  功能: 
*****************************************************/

using System;
using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;
using Newtonsoft.Json.Linq;
using UnityEngine;
using Application = UnityEngine.Device.Application;

namespace ZeroFramework
{
    public class ConfigKit : IUtility, IConfigKit
    {
        public readonly string LAUNCH_PATH;
        public JObject _G;
        private Dictionary<string, string> replaceRule;

        private List<string> loadPathTrace = new List<string>();

        public ConfigKit(string loadPath, Dictionary<string, string> replaceRule = null)
        {
            LAUNCH_PATH = loadPath;
            this.replaceRule = replaceRule;
            _G = CreateConfigByLink(LAUNCH_PATH);
        }
        
        public JToken this[string key]
        {
            get => Find(key).Item3;
            set
            {
                var result = Find(key);
                result.Item1[result.Item2] = value;
            }  
        }

        public T Get<T>(string key)
        {
            var token = this[key];
            if (token != null)
            {
                return token.ToObject<T>();
            }
            return default(T);
        }

        private (JObject, string, JToken) Find(string key)
        {
            string[] keys = key.Split('.');
            if (keys.Length < 1) return (null, null, null);
            if (keys.Length == 1)
            {
                if (_G.TryGetValue(key, out var value))
                    return (_G, key, value);
                return (null, null, null);
            }

            JObject jObj = _G;
            string keyItem = null;
            JToken valItem = null;
            for (int i = 0; i < keys.Length; i++)
            {
                if (jObj.TryGetValue(keys[i], out var item))
                {
                    keyItem = keys[i];
                    valItem = item;
                    if (valItem is JObject new_jObj)
                    {
                        jObj = new_jObj;
                    }
                }
                else
                {
                    return (null, null, null);
                }
            }
            return (jObj, keyItem, valItem);
        }

        private JObject CreateConfigByLink(string path)
        {
            if (!File.Exists(path))
            {
                Debug.LogWarning("[ Zero ] 加载终止：路径不存在, " + path);
                return null;
            }

            IFileKit fileKit = new FileKit();
            string yaml = ReConstructConfig(fileKit.TextTool.Read(path));
            JObject tempJObj1 = fileKit.Yaml2Json2Obj<JObject>(yaml);
            loadPathTrace.Add(path);
            // Debug.Log("[ Zero ] 加载配置: " + path);
            // return tempJObj1;
            JObject tempJobj2 = null;
            string applicationPath = tempJObj1["link"]?.ToString();
            while (applicationPath != null)
            {
                if (!File.Exists(applicationPath))
                {
                    Debug.LogWarning("[ Zero ] 加载终止：路径不存在, " + applicationPath);
                    break;
                }
                yaml = ReConstructConfig(fileKit.TextTool.Read(applicationPath));
                tempJobj2 = fileKit.Yaml2Json2Obj<JObject>(yaml);
                OverrideConfig(tempJObj1, tempJobj2);
                // Debug.Log("[ Zero ] 加载配置成功: " + applicationPath);
                loadPathTrace.Add(applicationPath);
                if (tempJobj2 == null) break; //如果文件为空，则为null（合法）
                applicationPath = tempJobj2["link"]?.ToString();
                if (applicationPath != null && loadPathTrace.Contains(applicationPath)) //存在环路则直接返回，避免死循环加载
                {
                    Debug.LogWarning("[ Zero ] 加载终止：link存在环路，请检查！");
                    break;
                }
            }
            return tempJObj1;
        }

        private JObject OverrideConfig(JObject oldObj, JObject newObj)
        {
            if (oldObj == null || newObj == null) return null;
            foreach (var pair in newObj)
            {
                if (oldObj.ContainsKey(pair.Key))
                {
                    //如果是字典类，则继续递归
                    if (oldObj[pair.Key] is JObject)
                    {
                        oldObj[pair.Key] = OverrideConfig(oldObj[pair.Key] as JObject, newObj[pair.Key] as JObject);
                    }
                    else //如果非字典类则直接更新
                    {
                        oldObj[pair.Key] = pair.Value;
                    }
                }
                else
                {
                    oldObj.Add(pair.Key, pair.Value);
                }
            }
            return oldObj;
        }
        
        private string ReConstructConfig(string input)
        {
            string pattern = "\\$\\{([^}]*)\\}"; // 匹配 ${...} 内的内容  
            MatchCollection matches = Regex.Matches(input, pattern);  
  
            foreach (Match match in matches)  
            {  
                string content = match.Groups[1].Value.ToLower(); // 提取 ${...} 内的内容  
                if (replaceRule != null && replaceRule.TryGetValue(content, out string replacementValue))  
                {  
                    input = input.Replace(match.Value, replacementValue); // 替换匹配的字符串  
                }  
            }  
            return input;
        }
    }
}