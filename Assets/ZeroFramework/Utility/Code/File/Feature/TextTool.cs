/****************************************************
  文件：TextTool.cs
  作者：聪头
  邮箱：1322080797@qq.com
  日期：2023/12/27 19:51:22
  功能：
*****************************************************/
using System;
using System.Collections;
using System.IO;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Networking;
using UnityEngine.UI;

namespace ZeroFramework
{
    public class TextTool
    {
        public string Read(string path)
        {
            if (File.Exists(path))
            {
                return File.ReadAllText(path);
            }
            return "";
        }
        
        public void Write(string path, string content)
        {
            string dir = Path.GetDirectoryName(path);
            if (dir != null && !Directory.Exists(dir))
            {
                Directory.CreateDirectory(dir);
            }
            File.WriteAllText(path, content);
        }
        
        public async void ReadAsync(string path, Action<string> readCallback)
        {
            if (File.Exists(path))
            {
                string content = await File.ReadAllTextAsync(path);
                readCallback?.Invoke(content);
            }
        }
        
        public async void WriteAsync(string path, string content, Action writeCallback)
        {
            string dir = Path.GetDirectoryName(path);
            if (dir != null && !Directory.Exists(dir))
            {
                Directory.CreateDirectory(dir);
            }
            await File.WriteAllTextAsync(path, content);
            writeCallback?.Invoke();
        }
        
        public IEnumerator ReadFromUri(string uri, UnityAction<string> callback)
        {
            UnityWebRequest request = UnityWebRequest.Get(uri);
            yield return request.SendWebRequest();
            if (request.isDone)
            {
                callback?.Invoke(request.downloadHandler.text);
            }
            request.Dispose();
        }
    }
}