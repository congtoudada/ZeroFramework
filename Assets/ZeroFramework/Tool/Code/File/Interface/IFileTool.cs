namespace ZeroFramework.Interface
{
    public interface IFileTool
    {
        BytesFileTool BytesTool { get; }
        ImageFileTool ImageTool { get; }
        JsonFileTool JsonTool { get; }
        TextFileTool TextTool { get; }
        YamlFileTool YamlTool { get; }
        
        string BytesToString(byte[] bytes);
        byte[] StringToBytes(string str);
    }
}