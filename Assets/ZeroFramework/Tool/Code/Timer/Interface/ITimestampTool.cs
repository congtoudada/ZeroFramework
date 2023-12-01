namespace ZeroFramework
{
    public interface ITimestampTool
    {
        /// <summary>
        /// 获得1970以来的时间戳
        /// </summary>
        /// <param name="isMilliseconds">是则毫秒级，否则秒级</param>
        /// <returns></returns>
        long GetTimestamp(bool isMilliseconds = true);

        /// <summary>
        /// 根据毫秒时间戳获取字符串
        /// </summary>
        /// <param name="millionSeconds">1970至今的毫秒时间戳</param>
        /// <param name="format">时间字符串格式。默认yyyy-MM-dd HH:mm:ss</param>
        /// <returns></returns>
        string GetTimeString(long millionSeconds, string format = "yyyy-MM-dd HH:mm:ss");
    }
}