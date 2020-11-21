using System;
using System.Collections;
using System.Collections.Generic;
using EventBusSystem;
using TMPro;
using UnityEngine;

public class CardView : MonoBehaviour
{
    [SerializeField] private SpriteRenderer _spriteRenderer;
    [SerializeField] private TMP_Text _nameText;
    [SerializeField] private TMP_Text _descriptionText;
    [SerializeField] private TMP_Text _hpText;
    [SerializeField] private TMP_Text _manaText;
    [SerializeField] private TMP_Text _attackText;

    [SerializeField] private List<MeshRenderer> _allText;
    [SerializeField] private List<SpriteRenderer> _allSprites;



    public void SetSortingLayer(string layer)
    {
        foreach (var sprite in _allSprites)
        {
            sprite.sortingLayerName = layer;
        }

        foreach (var text in _allText)
        {
            text.sortingLayerName = layer;
        }
    }

    public void SetArt(Sprite s)
    {
        _spriteRenderer.sprite = s;
    }
    
    public void SetNameText(string text)
    {
        _nameText.text = text;
    }

    public void SetDescriptionText(string text)
    {
        _descriptionText.text = text;
    }
    
    public void SetHpText(string text)
    {
        _hpText.text = text;
    }
    
    public void SetManaText(string text)
    {
        _manaText.text = text;
    }
    
    public void SetAttackText(string text)
    {
        _attackText.text = text;
    }
}