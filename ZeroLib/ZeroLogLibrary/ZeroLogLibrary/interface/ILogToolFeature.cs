/****************************************************
  文件：ILogTool.cs
  作者：聪头
  邮箱：1322080797@qq.com
  日期：2023/11/22 14:14:58
  功能：Nothing
*****************************************************/
namespace ZeroFramework
{
    public interface ILogToolFeature
    {
        /// <summary>
        /// 打印Debug信息
        /// </summary>
        /// <param name="message">日志内容</param>
        void Debug(object message);

        /// <summary>
        /// 打印Info信息
        /// </summary>
        /// <param name="message">日志内容</param>
        void Info(object message);

        /// <summary>
        /// 打印Warn信息
        /// </summary>
        /// <param name="message">日志内容</param>
        void Warn(object message);

        /// <summary>
        /// 打印Error信息
        /// </summary>
        /// <param name="message">日志内容</param>
        void Error(object message);

        /// <summary>
        /// 打印Fatal信息
        /// </summary>
        /// <param name="message">日志内容</param>
        void Fatal(object message);
    }
}
