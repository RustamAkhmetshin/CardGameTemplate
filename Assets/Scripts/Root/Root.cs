using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Root : MonoBehaviour
{
    private static Root _instance;
    private static Factory _factory;
    
    private bool _initialized;
    
    private IUIManager _uiManager;
    private IGameManager _gameManager;
    private IDownloadManager _downloadManager;
    private ITween _tweener;

    void Awake()
    {
        _factory = GetComponent<Factory>();
        if (_instance == null)
        {
            _instance = this;
        }
        else if (_instance == this)
        {
            Destroy(gameObject);
        }

        DontDestroyOnLoad(gameObject);
        
        Initialize();
    }

    public void Initialize()
    {
        _initialized = true;
        
        GameManager.StartGame();
    }
    
    public static IUIManager UIManager
    {
        get { return _instance._uiManager = _instance._uiManager ?? _factory.GetUIManager(); }
    }

    public static IGameManager GameManager
    {
        get { return _instance._gameManager = _instance._gameManager ?? _factory.GetGameManager(); }
    }

    public static IDownloadManager DownloadManager
    {
        get { return _instance._downloadManager = _instance._downloadManager ?? _factory.GetDownloadManager(); }
    }
    
    public static ITween Tweener
    {
        get { return _instance._tweener = _instance._tweener ?? _factory.Tweener(); }
    }
}