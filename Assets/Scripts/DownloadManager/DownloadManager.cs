using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class DownloadManager : MonoBehaviour, IDownloadManager
{
    public void DownloadImage(string url, Action<Texture2D> callback)
    {
        StartCoroutine(GetTexture(url, callback));
    }
    
    private IEnumerator GetTexture(string url, Action<Texture2D> callback) {
        UnityWebRequest www = UnityWebRequestTexture.GetTexture(url);

        yield return www.SendWebRequest();

        if(www.isNetworkError) {
            Debug.Log(www.error);
        }
        else {
            Texture2D webTexture = ((DownloadHandlerTexture)www.downloadHandler).texture as Texture2D;
            callback(webTexture);
        }
    }
}