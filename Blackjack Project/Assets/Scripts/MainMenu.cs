using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void ChooseGame()
    {
        SceneManager.LoadScene("GameSelection");
    }
    public void PlayBJ()
    {
        SceneManager.LoadScene("GameScene");
    }

    public void BacktoMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
