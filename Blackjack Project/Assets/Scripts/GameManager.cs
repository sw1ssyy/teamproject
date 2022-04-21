using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    // Start is called before the first frame update

    //Buttons for Blackjack
    public Button dealButton;
    public Button hitButton;
    public Button StandButton;
    public Button BetButton;
    
    private int standindex = 0;

    public PlayerScript playerScript;
    public PlayerScript dealerScript;

    public Text TotalMoney;
    public Text BetAmount;
    public Text PlayerHandAmount;
    public Text DealerHandAmount;
    public Text mainText;
    public Text StandButtonText;

    // Hidden Card

    public GameObject hiddencard;

    int gamepot = 0;
    void Start()
    {
        // Add on click listeners to the buttons
        dealButton.onClick.AddListener(() => DealClicked());
        hitButton.onClick.AddListener(() => HitClicked());
        StandButton.onClick.AddListener(() => StandClicked());
        BetButton.onClick.AddListener(() => BetClicked());
    }

    private void DealClicked()
    {
        // Reset round, hide text, prep for new hand
        playerScript.ResetGame();
        dealerScript.ResetGame();
        // Hide deal hand score at start of deal
        DealerHandAmount.gameObject.SetActive(false);
        mainText.gameObject.SetActive(false);
        DealerHandAmount.gameObject.SetActive(false);
        GameObject.Find("Deck").GetComponent<DeckScript>().cardShuffle();
        playerScript.StartHand();
        dealerScript.StartHand();
        // Update the scores displayed
        PlayerHandAmount.text = "Hand: " + playerScript.handValue.ToString();
        DealerHandAmount.text = "Hand: " + dealerScript.handValue.ToString();
        // Place card back on dealer card, hide card
        hiddencard.GetComponent<Renderer>().enabled = true;
        // Adjust buttons visibility
        dealButton.gameObject.SetActive(false);
        hitButton.gameObject.SetActive(true);
        StandButton.gameObject.SetActive(true);
        // Set standard pot size
        gamepot = 40;
        BetAmount.text = "Bets: £" + gamepot.ToString();
        playerScript.ChangeMoney(-20);
        TotalMoney.text = "£" + playerScript.GetMoney().ToString();

    }

    private void HitClicked()
    {
        // Check that there is still room on the table
        if (playerScript.cardIndex <= 10)
        {
            playerScript.GetCard();
            PlayerHandAmount.text = "Hand: " + playerScript.handValue.ToString();
            if (playerScript.handValue > 20) RoundOver();
        }
    }

    private void StandClicked()
    {
        standindex++;
        if (standindex > 1) RoundOver();
        HitDealer();
        StandButtonText.text = "Call";
    }

    private void HitDealer()
    {
        while (dealerScript.handValue < 16 && dealerScript.cardIndex < 10)
        {
            dealerScript.GetCard();
            DealerHandAmount.text = "Hand: " + dealerScript.handValue.ToString();
            if (dealerScript.handValue > 20) RoundOver();
        }
    }

    // Check for winnner and loser, hand is over
    void RoundOver()
    {
        // Booleans (true/false) for bust and blackjack/21
        bool playerBust = playerScript.handValue > 21;
        bool dealerBust = dealerScript.handValue > 21;
        bool player21 = playerScript.handValue == 21;
        bool dealer21 = dealerScript.handValue == 21;
        // If stand has been clicked less than twice, no 21s or busts, quit function
        if (standindex < 2 && !playerBust && !dealerBust && !player21 && !dealer21) return;
        bool roundOver = true;
        // All bust, bets returned
        if (playerBust && dealerBust)
        {
            mainText.text = "All Bust: Bets returned";
            playerScript.ChangeMoney(gamepot / 2);
        }
        // if player busts, dealer didnt, or if dealer has more points, dealer wins
        else if (playerBust || (!dealerBust && dealerScript.handValue > playerScript.handValue))
        {
            mainText.text = "Dealer wins!";
        }
        // if dealer busts, player didnt, or player has more points, player wins
        else if (dealerBust || playerScript.handValue > dealerScript.handValue)
        {
            mainText.text = "You win  £" + gamepot/2 + "!!";
            playerScript.ChangeMoney(gamepot* 2);
        }
        //Check for tie, return bets
        else if (playerScript.handValue == dealerScript.handValue)
        {
            mainText.text = "Push: Bets returned";
            playerScript.ChangeMoney(gamepot / 2);
        }
        else
        {
            roundOver = false;
        }
        // Set ui up for next move / hand / turn
        if (roundOver)
        {
            hitButton.gameObject.SetActive(false);
            StandButton.gameObject.SetActive(false);
            dealButton.gameObject.SetActive(true);
            mainText.gameObject.SetActive(true);
            DealerHandAmount.gameObject.SetActive(true);
            hiddencard.GetComponent<Renderer>().enabled = false;
            TotalMoney.text = "£" + playerScript.GetMoney().ToString();
            standindex = 0;
        }
    }

    // Add money to pot if bet clicked
    void BetClicked()
    {
        Text newBet = BetButton.GetComponentInChildren(typeof(Text)) as Text;
        int intBet = int.Parse(newBet.text.ToString().Remove(0, 1));
        playerScript.ChangeMoney(-intBet);
        TotalMoney.text = "£" + playerScript.GetMoney().ToString();
        gamepot += (intBet * 2);
        BetAmount.text = "Bet: £" + gamepot.ToString();
    }
}