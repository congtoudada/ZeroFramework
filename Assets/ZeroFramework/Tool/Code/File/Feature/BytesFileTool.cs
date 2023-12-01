using System;
using System.Collections;
using System.IO;
using UnityEngine.Events;
using UnityEngine.Networking;

namespace ZeroFramework
{
    public class BytesFileTool
    {
        /// <summary>
        /// 同步读字节文件
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        public byte[] Read(string path)
        {
            if (File.Exists(path))
            {
                return File.ReadAllBytes(path);
            }
            return null;
        }

        /// <summary>
        /// 同步写字节文件
        /// </summary>
        /// <param name="path"></param>
        /// <param name="bytes"></param>
        public void Write(string path, byte[] bytes)
        {
            string dir = Path.GetDirectoryName(path);
            if (dir != null && !Directory.Exists(dir))
            {
                Directory.CreateDirectory(dir);
            }
            File.WriteAllBytes(path, bytes);
        }
        
        /// <summary>
        /// 异步读字节文件
        /// </summary>
        /// <param name="path"></param>
        /// <param name="readCallback"></param>
        public async void ReadAsync(string path, Action<byte[]> readCallback)
        {
            if (File.Exists(path))
            {
                byte[] content = await File.ReadAllBytesAsync(path);
                readCallback?.Invoke(content);
            }
        }
        
        /// <summary>
        /// 异步写字节文件
        /// </summary>
        /// <param name="path"></param>
        /// <param name="content"></param>
        /// <param name="writeCallback"></param>
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