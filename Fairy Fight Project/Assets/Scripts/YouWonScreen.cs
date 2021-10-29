using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;



public class YouWonScreen : MonoBehaviour
{
    public void RestartButton()
    {
        SceneManager.LoadScene("map");
    }

    public void MainMenuButton()
    {
        SceneManager.LoadScene("MainMenu");
    }

}
