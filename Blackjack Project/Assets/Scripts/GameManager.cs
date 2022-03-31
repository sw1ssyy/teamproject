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

   public PlayerScript playerScript;
   public PlayerScript dealerScript;
    void Start()
    { 
        // Listeners for Buttons on HUD
        dealButton.onClick.AddListener(() => DealClicked());
        hitButton.onClick.AddListener(() => HitClicked());
        StandButton.onClick.AddListener(() => StandClicked());
    }

    private void StandClicked()
    {
        throw new NotImplementedException();
    }

    private void HitClicked()
    {
        throw new NotImplementedException();
    }

    private void DealClicked()
    {
        GameObject.Find("Deck").GetComponent<DeckScript>().cardShuffle();
       playerScript.StartHand();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
