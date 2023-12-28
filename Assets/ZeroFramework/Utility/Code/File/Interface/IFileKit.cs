/****************************************************
  文件：IFileKit.cs
  作者：聪头
  邮箱: 1322080797@qq.com
  日期：2021/11/14 16:29:07
  功能：文件操作工具类
*****************************************************/

namespace ZeroFramework
{
    public interface IFileKit : IUtility
    {
        BytesTool BytesTool { get; }
        ImageTool ImageTool { get; }
        JsonTool JsonTool { get; }
        TextTool TextTool { get; }
        YamlTool YamlTool { get; }
        
        string BytesToString(byte[] bytes);
        byte[] StringToBytes(string str);

        T Yaml2Json2Obj<T>(string yamlStr);
        
        T Path2Yaml2Json2Obj<T>(string path);

    }
}