using System.Collections;
using System.Collections.Generic;
using EventBusSystem;
using UnityEngine;

public class HandController : MonoBehaviour, IChangeButtonHandler, IItemRemovingHandler, IItemDestroyHandler
{
    private const float DEGREES_RANGE = 30f;
    private const float DELTA_DEGREES = 5f;
    
    [SerializeField] private GameObject _parentPrefab;
    [SerializeField] private GameObject _cardPrefab;

    private List<Transform> _fanItems;
    private CardData _cardData;
    private int _changeCardIndex = 0;

    public void Init(CardData cardData)
    {
        _fanItems = new List<Transform>();
        _cardData = cardData;
        
        for (int i = 0; i < cardData.cards.Count; i++)
        {
            Transform parent = Instantiate(_parentPrefab, transform).transform;
            Instantiate(_cardPrefab, parent).GetComponent<CardController>().Init(i, cardData.cards[i]);
            _fanItems.Add(parent);
        }
        
        CreateFanView();
    }

    public void CreateFanView()
    {
        float maxDegreeValue = _fanItems.Count / 2f * DELTA_DEGREES;
        List<Quaternion> stepRotations = new List<Quaternion>();

        for (int i = 0; i < _fanItems.Count; i++)
        {
            Root.Tweener.TweenRotation(_fanItems[i], Quaternion.Euler(new Vector3(0f, 0f, maxDegreeValue)));
            maxDegreeValue -= DELTA_DEGREES;
        }
    }
    
    public void OnButtonClick()
    {
        int type = Random.Range(0, 3);
        switch (type)
        {
            case 0:
                _cardData.cards[_changeCardIndex++].HP = Random.Range(-1, 20);
                break;
            case 1:
                _cardData.cards[_changeCardIndex++].Mana = Random.Range(-1, 20);
                break;
            case 2:
                _cardData.cards[_changeCardIndex++].Attack = Random.Range(-1, 20);
                break;
        }

        if (_changeCardIndex >= _cardData.cards.Count)
        {
            _changeCardIndex = 0;
        }
        
        EventBus.RaiseEvent<ICardPropertiesChangeHandler>(h => h.PropertiesChanged(_cardData.cards));
    }
    
    private void OnEnable()
    {
        EventBus.Subscribe(this);
    }

    private void OnDisable()
    {
        EventBus.Unsubscribe(this);
    }

    public void HandleItemRemoving(int cardId)
    {
        CreateFanView();
    }

    public void OnParentItemDestroy(Transform item)
    {
        _fanItems.Remove(item);
    }
}
