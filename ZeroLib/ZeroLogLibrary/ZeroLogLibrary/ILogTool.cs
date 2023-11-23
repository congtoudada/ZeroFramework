/****************************************************
  文件：ILogTool.cs
  作者：聪头
  邮箱：1322080797@qq.com
  日期：2023/11/22 14:14:58
  功能：Nothing
*****************************************************/
namespace ZeroFramework
{
    public interface ILogTool
    {
        void Debug(object message);
        
        void Info(object message);
        
        void Warn(object message);
        
        void Error(object message);
        
        void Fatal(object message);
    }
}
