/****************************************************
  文件：FileTool.cs
  作者：聪头
  邮箱:  1322080797@qq.com
  日期：2021/11/14 16:29:07
  功能：文件操作工具类
*****************************************************/

using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Networking;
using ZeroFramework.Interface;


namespace ZeroFramework
{
    public class FileTool : IFileTool
    {
        #region 文本文件操作
        private TextFileTool Text
        {
            get
            {
                if (_textFileTool == null)
                {
                    _textFileTool = new TextFileTool();
                }
                return _textFileTool;
            }
        }
        private TextFileTool _textFileTool;
        #endregion

        #region 字节数组操作
        private BytesFileTool Bytes
        {
            get
            {
                if (_bytesFileTool == null)
                {
                    _bytesFileTool = new BytesFileTool();
                }
                return _bytesFileTool;
            }
        }
        private BytesFileTool _bytesFileTool;
        #endregion
        
        #region Json操作
        private JsonFileTool Json
        {
            get
            {
                if (_jsonFileTool == null)
                {
                    _jsonFileTool = new JsonFileTool();
                }
                return _jsonFileTool;
            }
        }
        private JsonFileTool _jsonFileTool;
        #endregion
        
        #region Yaml操作
        private YamlFileTool Yaml
        {
            get
            {
                if (_yamlFileTool == null)
                {
                    _yamlFileTool = new YamlFileTool();
                }
                return _yamlFileTool;
            }
        }
        private YamlFileTool _yamlFileTool;
        #endregion
        
        #region Image操作
        private ImageFileTool Image
        {
            get
            {
                if (_imageFileTool == null)
                {
                    _imageFileTool = new ImageFileTool();
                }
                return _imageFileTool;
            }
        }
        private ImageFileTool _imageFileTool;
        private BytesFileTool _bytesTool;
        private ImageFileTool _imageTool;
        private JsonFileTool _jsonTool;
        private TextFileTool _textTool;
        private YamlFileTool _yamlTool;
        private BytesFileTool _bytesTool1;
        private ImageFileTool _imageTool1;
        private JsonFileTool _jsonTool1;
        private TextFileTool _textTool1;
        private YamlFileTool _yamlTool1;

        #endregion
        
        #region 实现接口
        //字节数组 -> 字符串
        BytesFileTool IFileTool.BytesTool => Bytes;

        ImageFileTool IFileTool.ImageTool => Image;

        JsonFileTool IFileTool.JsonTool => Json;

        TextFileTool IFileTool.TextTool => Text;

        YamlFileTool IFileTool.YamlTool => Yaml;

        public string BytesToString(byte[] bytes)
        {
            return System.Text.Encoding.Default.GetString(bytes, 0, bytes.Length);
        }
        //字符串 -> 字节数组
        public byte[] StringToBytes(string str)
        {
            return System.Text.Encoding.Default.GetBytes(str);
        }
        #endregion
    }
}