using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{   [SerializeField]
    float startingTime ;
    float currentTime = 0;

    [SerializeField] Text countdown;
    
    [SerializeField] string endGameMenu;

    void Start()
    {
        currentTime = startingTime;
    }

    void Update()
    {

        currentTime -= 1 * Time.deltaTime;
        countdown.text = currentTime.ToString("f0");

        if(currentTime <= 0)
        {
            currentTime = 0;
            Application.LoadLevel(endGameMenu);
        }
    }
}
