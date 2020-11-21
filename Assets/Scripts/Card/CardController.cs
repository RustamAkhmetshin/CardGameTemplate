using System;
using System.Collections;
using System.Collections.Generic;
using EventBusSystem;
using UnityEngine;

public class CardController : MonoBehaviour, ICardPropertiesChangeHandler
{
    private CardView _cardView;

    [SerializeField] private int _cardId;
    private int _previousHpValue;
    private int _previousManaValue;
    private int _previousAttackValue;
    private IDownloadManager _downloadManager => Root.DownloadManager;
    private ITween _tweener => Root.Tweener;
    
    private void Awake()
    {
        _cardView = GetComponent<CardView>();
    }
    
    public void Init(int orderId, Card card)
    {
        _cardId = orderId;
        _previousHpValue = card.HP;
        _previousManaValue = card.Mana;
        _previousAttackValue = card.Attack;
        
        _cardView.SetSortingLayer("Card " + orderId);
        _cardView.SetNameText(card.Name);
        _cardView.SetDescriptionText(card.Description);
        _cardView.SetHpText(card.HP.ToString());
        _cardView.SetManaText(card.Mana.ToString());
        _cardView.SetAttackText(card.Attack.ToString());
        
        _downloadManager.DownloadImage(GlobalVars.PHOTOS_URL, (texture2D) =>
        {
            _cardView.SetArt(Sprite.Create(texture2D, new Rect(0, 0, texture2D.width, texture2D.height), new Vector2(0.5f,0.5f)));
        });
    }

    public void PropertiesChanged(List<Card> cards)
    {
        if(cards.Count <= _cardId) 
            return;
        
        if (_previousHpValue != cards[_cardId].HP)
        {
            _tweener.TweenInt(_previousHpValue, cards[_cardId].HP, (value) =>
            {
                _cardView.SetHpText(value.ToString());
            }, () =>
            {
                if(cards.Count <= _cardId) 
                    return;
                _previousHpValue = cards[_cardId].HP;
                if (_previousHpValue < 0)
                {
                    DestroyProcess();
                }
            });
        }
        
        if (_previousManaValue != cards[_cardId].Mana)
        {
            _tweener.TweenInt(_previousManaValue, cards[_cardId].Mana, (value) =>
            {
                _cardView.SetManaText(value.ToString());
            }, () =>
            {
                if(cards.Count <= _cardId) 
                    return;
                _previousManaValue = cards[_cardId].Mana;
                if (_previousManaValue < 0)
                {
                    DestroyProcess();
                }
            });
        }
        
        if (_previousAttackValue != cards[_cardId].Attack)
        {
            _tweener.TweenInt(_previousAttackValue, cards[_cardId].Attack, (value) =>
            {
                _cardView.SetAttackText(value.ToString());
            }, () =>
            {
                if(cards.Count <= _cardId) 
                    return;
                _previousAttackValue = cards[_cardId].Attack;
                if (_previousAttackValue < 0)
                {
                    DestroyProcess();
                }
            });
            
        }

    }

    private void DestroyProcess()
    {
        transform.parent.gameObject.SetActive(false);
        EventBus.RaiseEvent<IItemRemovingHandler>(h => h.HandleItemRemoving(_cardId));
        Destroy(gameObject);
    }

    void OnDestroy()
    {
        Destroy(transform.parent.gameObject);
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
