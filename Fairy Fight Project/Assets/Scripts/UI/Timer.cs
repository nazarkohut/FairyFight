using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{   [SerializeField]
    float startingTime;
    public static float currentTime = 0;

    [SerializeField] Text countdown;

    void Start()
    {
    }

    void Update()
    {
        if( Fairy.HealthPoint >= 0)
        {
            currentTime += 1 * Time.deltaTime;
        }
        countdown.text = currentTime.ToString("f0");   
    }
}
