using YamlDotNet.Serialization;

namespace ZeroFramework
{
    public class YamlFileTool
    {
        /// <summary>
        /// 将对象转化为yaml字符串
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public string SerializeObject(object obj)
        {
            var serializer = new Serializer();
            var yaml = serializer.Serialize(obj);
            return yaml;
        }

        /// <summary>
        /// 将yaml字符串反序列化为对象
        /// </summary>
        /// <param name="yaml"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public T DeserializeObject<T>(string yaml)
        {
            var deserializer = new Deserializer();
            return deserializer.Deserialize<T>(yaml);
        }
    }
}