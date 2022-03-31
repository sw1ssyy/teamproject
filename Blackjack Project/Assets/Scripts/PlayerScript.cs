using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    // Keeps Players and Dealers cards and value

    public CardScript cardScript;
    public DeckScript deckScript;

    public int handValue = 0;

    private int money = 100;

    public GameObject[] hand;

    public int cardIndex = 0;

    List<CardScript> AceList = new List<CardScript>();
  public void StartHand()
    {
        GetCard();
        GetCard();
    }

    public int GetCard()
    {
        int cardvalue = deckScript.DealCard(hand[cardIndex].GetComponent<CardScript>());
        hand[cardIndex].GetComponent<Renderer>().enabled = true;

        handValue += cardvalue;
        if(cardvalue == 1)
        {
            AceList.Add(hand[cardIndex].GetComponent<CardScript>());
        }
        cardIndex++;
        return handValue;
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
