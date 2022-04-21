using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    // Keeps Players and Dealers cards and value

    public CardScript cardScript;
    public DeckScript deckScript;

    public int handValue = 0;
    // Users money to bet
    private int money = 1000;
  
    public GameObject[] hand;

    public int cardIndex = 0;

    List<CardScript> AceList = new List<CardScript>();

    // Method for Collecting two cards each time the player plays Blackjack
    public void StartHand()
    {
        GetCard();
        GetCard();
    }

    // Add a hand to the player/dealer's hand
    public int GetCard()
    {
        // Get a card, use deal card to assign sprite and value to card on table
        int cardValue = deckScript.DealCard(hand[cardIndex].GetComponent<CardScript>());
        // Show card on game screen
        hand[cardIndex].GetComponent<Renderer>().enabled = true;
        // Add card value to running total of the hand
        handValue += cardValue;
        // If value is 1, it is an ace
        if (cardValue == 1)
        {
            AceList.Add(hand[cardIndex].GetComponent<CardScript>());
        }
        // Cehck if we should use an 11 instead of a 1
        AceCheck();
        cardIndex++;
        return handValue;
    }

    // Search for needed ace conversions, 1 to 11 or vice versa
    public void AceCheck()
    {
        // for each ace in the lsit check
        foreach (CardScript ace in AceList)
        {
            if (handValue + 10 < 22 && ace.GetCardValue() == 1)
            {
                // if converting, adjust card object value and hand
                ace.SetCardValue(11);
                handValue += 10;
            }
            else if (handValue > 21 && ace.GetCardValue() == 11)
            {
                // if converting, adjust gameobject value and hand value
                ace.SetCardValue(1);
                handValue -= 10;
            }
        }
    }

    // Add or subtract from money, for bets
    public void ChangeMoney(int amount)
    {
        money += amount;
    }

    // Output players current money amount
    public int GetMoney()
    {
        return money;
    }

    // Hides all cards, resets the needed variables
    public void ResetGame()
    {
        for (int i = 0; i < hand.Length; i++)
        {
            hand[i].GetComponent<CardScript>().ResetCard();
            hand[i].GetComponent<Renderer>().enabled = false;
        }
        cardIndex = 0;
        handValue = 0;
        AceList = new List<CardScript>();
    }
}
