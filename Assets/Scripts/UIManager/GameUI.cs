using System.Collections;
using System.Collections.Generic;
using EventBusSystem;
using UnityEngine;
using UnityEngine.UI;

public class GameUI : Window
{
    [SerializeField] private Button _changeButton;
    
    private void Start()
    {
        _changeButton.onClick.AddListener(() =>
        {
            EventBus.RaiseEvent<IChangeButtonHandler>(h => h.OnButtonClick());
        });
    }

    
}