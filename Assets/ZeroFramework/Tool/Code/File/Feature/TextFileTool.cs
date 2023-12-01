using System;
using System.Collections;
using System.IO;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Networking;
using UnityEngine.UI;

namespace ZeroFramework
{
    public class TextFileTool
    {
        /// <summary>
        /// 同步读文本文件
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        public string Read(string path)
        {
            if (File.Exists(path))
            {
                return File.ReadAllText(path);
            }
            return "";
        }
        
        /// <summary>
        /// 同步写文本文件
        /// </summary>
        /// <param name="path"></param>
        /// <param name="content"></param>
        public void Write(string path, string content)
        {
            string dir = Path.GetDirectoryName(path);
            if (dir != null && !Directory.Exists(dir))
            {
                Directory.CreateDirectory(dir);
            }
            File.WriteAllText(path, content);
        }
        
        /// <summary>
        /// 异步读文本文件
        /// </summary>
        /// <param name="path"></param>
        /// <param name="readCallback"></param>
        public async void ReadAsync(string path, Action<string> readCallback)
        {
            if (File.Exists(path))
            {
                string content = await File.ReadAllTextAsync(path);
                readCallback?.Invoke(content);
            }
        }
        
        /// <summary>
        /// 异步写文本文件
        /// </summary>
        /// <param name="path"></param>
        /// <param name="content"></param>
        /// <param name="writeCallback"></param>
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
        
        /// <summary>
        /// 利用协程从网络读取文本文件
        /// </summary>
        /// <param name="uri"></param>
        /// <param name="callback"></param>
        /// <returns></returns>
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