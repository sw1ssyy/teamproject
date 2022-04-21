using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
   /// <summary>
   /// Function used to allow the user to move to the game selection scene on the website
   /// </summary>
    public void ChooseGame()
    {
        SceneManager.LoadScene("GameSelection");
    }
    /// <summary>
    /// Function allows the user to load the blackjack scene on the website
    /// </summary>
    public void PlayBJ()
    {
        SceneManager.LoadScene("GameScene");
    }
    /// <summary>
    /// Allows the user to return to the main menu when inside a game scene
    /// </summary>
    public void BacktoMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
