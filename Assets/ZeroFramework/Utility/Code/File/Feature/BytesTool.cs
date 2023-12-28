/****************************************************
  文件：BytesTool.cs
  作者：聪头
  邮箱：1322080797@qq.com
  日期：2023/12/27 19:51:22
  功能：
*****************************************************/
using System;
using System.Collections;
using System.IO;
using UnityEngine.Events;
using UnityEngine.Networking;

namespace ZeroFramework
{
    public class BytesTool
    {
        public byte[] Read(string path)
        {
            if (File.Exists(path))
            {
                return File.ReadAllBytes(path);
            }
            return null;
        }

        public void Write(string path, byte[] bytes)
        {
            string dir = Path.GetDirectoryName(path);
            if (dir != null && !Directory.Exists(dir))
            {
                Directory.CreateDirectory(dir);
            }
            File.WriteAllBytes(path, bytes);
        }
        
        public async void ReadAsync(string path, Action<byte[]> readCallback)
        {
            if (File.Exists(path))
            {
                byte[] content = await File.ReadAllBytesAsync(path);
                readCallback?.Invoke(content);
            }
        }
        
        public async void WriteAsync(string path, byte[] content, Action writeCallback)
        {
            string dir = Path.GetDirectoryName(path);
            if (dir != null && !Directory.Exists(dir))
            {
                Directory.CreateDirectory(dir);
            }
            await File.WriteAllBytesAsync(path, content);
            writeCallback?.Invoke();
        }
    }
}