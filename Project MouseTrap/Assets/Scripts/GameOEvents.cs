//Change scene event system
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOEvents : MonoBehaviour
{
    // Start is called before the first frame update
    public void ReplayGame()
    {
        SceneManager.LoadScene("House_M"); //SceneManager.LoadScene("Forest"); //House_M
    }

    // Update is called once per frame
    public void QuitGame()
    {
        Application.Quit();
    }

    public void StartGame() 
    {
        SceneManager.LoadScene("House_M"); //SceneManager.LoadScene("Forest");
    }
    public void MenuScene() 
    {
        SceneManager.LoadScene("MainMenu"); //SceneManager.LoadScene("Forest");
    }
    public void CreditsScene() 
    {
        SceneManager.LoadScene("CreditsScene"); //SceneManager.LoadScene("Forest");
    }
}
