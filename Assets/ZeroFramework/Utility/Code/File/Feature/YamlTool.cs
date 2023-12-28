/****************************************************
  文件：YamlTool.cs
  作者：聪头
  邮箱：1322080797@qq.com
  日期：2023/12/27 19:51:22
  功能：
*****************************************************/
using System.IO;
using YamlDotNet.Serialization;

namespace ZeroFramework
{
    public class YamlTool
    {
        public string YamlToJson(string yaml)
        {
            var deserializer = new DeserializerBuilder().Build();
            var yamlObject = deserializer.Deserialize(new StringReader(yaml));
            if (yamlObject != null)
            {
                var serializer = new SerializerBuilder()
                    .JsonCompatible()
                    .Build();
                return serializer.Serialize(yamlObject);
            }
            return "";
        }
        
        public string SerializeObject(object obj)
        {
            var serializer = new Serializer();
            var yaml = serializer.Serialize(obj);
            return yaml;
        }

        public T DeserializeObject<T>(string yaml)
        {
            var deserializer = new Deserializer();
            return deserializer.Deserialize<T>(yaml);
        }
    }
}