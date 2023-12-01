using Newtonsoft.Json;

namespace ZeroFramework
{
    public class JsonFileTool
    {
        /// <summary>
        /// 将对象转化为json字符串
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public string SerializeObject(object obj)
        {
            #if ZERO_RELEASE
            return JsonConvert.SerializeObject(obj);
            #else
            return JsonConvert.SerializeObject(obj, Formatting.Indented);
            #endif
        }

        /// <summary>
        /// 将json字符串反序列化为对象
        /// </summary>
        /// <param name="json"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public T DeserializeObject<T>(string json)
        {
            return JsonConvert.DeserializeObject<T>(json);
        }
    }
}