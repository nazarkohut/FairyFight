using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class CandyCounter : MonoBehaviour
{
    public static int Candy;
    Text text;
    void Start()
    {
        text = GetComponent<Text>();
        Candy=0;
    }

    // Update is called once per frame
    void Update()
    {
        text.text = Candy.ToString();
        if(Candy>=100){
            SceneManager.LoadScene("WonScene");
        }
    }
}

