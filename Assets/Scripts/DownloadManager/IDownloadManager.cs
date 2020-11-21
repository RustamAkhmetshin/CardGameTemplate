using System;
using UnityEngine;

public interface IDownloadManager
{
    void DownloadImage(string url, Action<Texture2D> callback);
}