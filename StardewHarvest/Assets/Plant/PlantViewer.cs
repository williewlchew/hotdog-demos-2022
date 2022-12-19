using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlantViewer : MonoBehaviour
{
    public Plant _plant;
    public SpriteRenderer _sprite;
    public Sprite[] plantSprites;

    public void Start()
    {
        Refresh();
    }

    public void Refresh()
    {
        switch(_plant.state) 
        {
            case 1:
                _sprite.sprite = plantSprites[1];
                break;
            case 2:
                _sprite.sprite = plantSprites[2];
                break;
            case 3:
                _sprite.sprite = plantSprites[3];
                break;
            default:
                _sprite.sprite = plantSprites[0];
                break;
        }
    }
}
