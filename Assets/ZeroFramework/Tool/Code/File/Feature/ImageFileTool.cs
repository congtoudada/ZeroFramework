using System.Collections;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Networking;

namespace ZeroFramework
{
    public class ImageFileTool
    {
        /// <summary>
        /// 利用协程从网络读取图片，返回Texture2D
        /// </summary>
        /// <param name="uri"></param>
        /// <param name="callback"></param>
        /// <returns></returns>
        public IEnumerator ReadFromUri(string imageUrl, UnityAction<Texture2D> callback)
        {
            UnityWebRequest webRequest = UnityWebRequestTexture.GetTexture(imageUrl);
            yield return webRequest.SendWebRequest();
            DownloadHandlerTexture texRequest = webRequest.downloadHandler as DownloadHandlerTexture;
            if (texRequest != null && texRequest.isDone)
            {
                callback?.Invoke(texRequest.texture);
            }
            else
            {
                callback?.Invoke(null);
            }
            webRequest.Dispose();
        }

        /// <summary>
        /// 利用协程从网络读取图片，返回Sprite
        /// </summary>
        /// <param name="imageUrl"></param>
        /// <param name="callback"></param>
        /// <returns></returns>
        public IEnumerator ReadFromUriSprite(string imageUrl, UnityAction<Sprite> callback)
        {
            UnityWebRequest webRequest = UnityWebRequestTexture.GetTexture(imageUrl);
            yield return webRequest.SendWebRequest();
            DownloadHandlerTexture texRequest = webRequest.downloadHandler as DownloadHandlerTexture;
            if (texRequest != null && texRequest.isDone)
            {
                Texture2D texture2D = texRequest.texture;
                Sprite sprite = Sprite.Create(texture2D, new Rect(0, 0, texture2D.width, texture2D.height), new Vector2(0.5f, 0.5f));
                callback?.Invoke(sprite);
            }
            else
            {
                callback?.Invoke(null);
            }
            webRequest.Dispose();
        }
    }
}