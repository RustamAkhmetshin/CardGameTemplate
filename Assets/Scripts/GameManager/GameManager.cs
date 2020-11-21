using System.Collections;
using System.Collections.Generic;
using EventBusSystem;
using UnityEngine;

public class GameManager : MonoBehaviour, IGameManager
{
    [SerializeField] private CardData _cardsData;
    [SerializeField] private GameObject _handPrefab;
    [SerializeField] private GameObject _gameUIWindow;

    private bool _gameStarted;


    public void StartGame()
    {
        var hand = Instantiate(_handPrefab);
        var handController = hand.GetComponent<HandController>();
        
        handController?.Init(_cardsData);

        Root.UIManager.InitializeWindow<GameUI>(_gameUIWindow, Root.UIManager.GetMainCanvas().transform);

        _gameStarted = true;
    }

    public bool IsGameStarted()
    {
        return _gameStarted;
    }


}