using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeckScript : MonoBehaviour
{
    public Sprite[] cards;
    int[] cardvalues = new int[53];
    int currentIndex = 0;
    // Start is called before the first frame update
    void Start()
    {
        GetCardValues();
    }

    void GetCardValues()
    {
        int value = 0;
        // Loops to give each card a value;
       for (int i = 0; i < cards.Length; i++)
        {
            value = i;
            // Every 13 cards, the 
            value %= 13;
            if (value > 10 || value == 0)
            {
                value = 10;
            }
            cardvalues[i] = value++;
        }
        currentIndex = 1;
    }
    // Creates another deck of cards, and
    // Swaps the value and positons of cards with the orginal deck of cards
    // Sets the new value and new sprite
   
    public void cardShuffle()
    {
        for (int i = cards.Length - 1; i > 0; --i)
        {
            int r = Mathf.FloorToInt(Random.Range(0.0f, 1.0f) * cards.Length - 1) + 1;
            Sprite face = cards[i];
            cards[i] = cards[r];
            cards[r] = face;

            int value = cardvalues[i];
            cardvalues[r] = value;
        }
    }
    public int DealCard(CardScript CardScript)
    {
        CardScript.SetSprite(cards[currentIndex]);
        CardScript.SetCardValue(cardvalues[currentIndex]);
        currentIndex++;
        return CardScript.GetCardValue();
    }

    public Sprite GetCardBack()
    {
        return cards[0];
    }


    // Update is called once per frame
    void Update()
    {
        
    }
}
