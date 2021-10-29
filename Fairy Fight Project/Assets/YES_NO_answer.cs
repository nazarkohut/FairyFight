using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class YES_NO_answer : MonoBehaviour
{
    
  public void RestartButton()
    {
        SceneManager.LoadScene("WonScene");
    }

    public void MainMenuButton()
    {
        SceneManager.LoadScene("Lose");
    }
}
