using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Factory : MonoBehaviour
{
    [SerializeField] private GameObject _uiManager;
    [SerializeField] private GameObject _gameManager;
    [SerializeField] private GameObject _downloadManager;
    [SerializeField] private GameObject _tweener;
    
    public IUIManager GetUIManager()
    {
        return Instantiate(_uiManager, transform).GetComponent<IUIManager>();
    }

    public IGameManager GetGameManager()
    {
        return Instantiate(_gameManager, transform).GetComponent<IGameManager>();
    }

    public IDownloadManager GetDownloadManager()
    {
        return Instantiate(_downloadManager, transform).GetComponent<IDownloadManager>();
    }
    
    public ITween Tweener()
    {
        return Instantiate(_tweener, transform).GetComponent<ITween>();
    }
}