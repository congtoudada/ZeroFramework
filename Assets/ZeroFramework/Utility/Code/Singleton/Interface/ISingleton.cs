/****************************************************
  文件：ISingleton.cs
  作者：聪头
  邮箱：1322080797@qq.com
  日期：2023-11-30 16:18:02
  功能：
*****************************************************/
namespace ZeroFramework
{
    public interface ISingleton
    {
        void OnSingletonInit();

        int GetID();

        void ResetID();
    }
}