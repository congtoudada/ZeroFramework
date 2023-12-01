using System;
using System.Collections.Generic;
using System.Text;

namespace ZeroFramework
{
    public interface ILogTool
    {
        /// <summary>
        /// 设置打印日志的类型，对已经创建的logger无效
        /// </summary>
        /// <param name="logEnum">打印日志类型</param>
        public void SetLogEnum(LogEnum logEnum);

        /// <summary>
        /// 全局日志开关，对已经创建的logger无效
        /// </summary>
        /// <param name="is_enable">是否启用日志功能</param>
        public void SetEnable(bool is_enable);

        /// <summary>
        /// 返回所属类的logger对象，用于打印该类的日志信息
        /// </summary>
        /// <param name="type">所属类的类型</param>
        /// <returns>日志打印操作接口</returns>
        ILogToolFeature AllocateLogger(Type type);

        /// <summary>
        /// 打印一次Debug信息
        /// </summary>
        /// <param name="message">日志内容</param>
        /// <param name="type">所属类类型</param>
        void Debug(object message, Type type);

        /// <summary>
        /// 打印一次Info信息
        /// </summary>
        /// <param name="message">日志内容</param>
        /// <param name="type">所属类类型</param>
        void Info(object message, Type type);

        /// <summary>
        /// 打印一次Warn信息
        /// </summary>
        /// <param name="message">日志内容</param>
        /// <param name="type">所属类类型</param>
        void Warn(object message, Type type);

        /// <summary>
        /// 打印一次Error信息
        /// </summary>
        /// <param name="message">日志内容</param>
        /// <param name="type">所属类类型</param>
        void Error(object message, Type type);

        /// <summary>
        /// 打印一次Fatal信息
        /// </summary>
        /// <param name="message">日志内容</param>
        /// <param name="type">所属类类型</param>
        void Fatal(object message, Type type);
    }
}
