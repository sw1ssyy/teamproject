using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardScript : MonoBehaviour
{
   private int value = 0;

    public int GetCardValue()
    {
        return value;
    }
    public void SetCardValue(int cardValue)
    {
        value = cardValue;
    }

    public string GetSpriteName()
    {
        return GetComponent<SpriteRenderer>().sprite.name;
    }

    public void SetSprite(Sprite SpriteValue)
    {
        gameObject.GetComponent<SpriteRenderer>().sprite = SpriteValue;
    }
    public void ResetCard()
    {
        Sprite back = GameObject.Find("DeckController").GetComponent<DeckScript>().GetCardBack();
        gameObject.GetComponent<SpriteRenderer>().sprite = back;
        value = 0; 
        
    }

}
