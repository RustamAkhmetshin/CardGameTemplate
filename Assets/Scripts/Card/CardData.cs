using System.Collections;
using System.Collections.Generic;
using EventBusSystem;
using UnityEngine;

[CreateAssetMenu( fileName = "CardData", menuName = "CardData" )]
public class CardData : ScriptableObject, IItemRemovingHandler
{
    public List<Card> cards;

    void OnValidate()
    {
        if (Application.isPlaying)
        {
            EventBus.RaiseEvent<ICardPropertiesChangeHandler>(h => h.PropertiesChanged(cards));
        }
    }

    public void HandleItemRemoving(int cardId)
    {
        cards.Remove(cards[cardId]);
    }
    
    private void OnEnable()
    {
        EventBus.Subscribe(this);
    }

    private void OnDisable()
    {
        EventBus.Unsubscribe(this);
    }
}