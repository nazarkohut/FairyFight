using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Deal_damage : MonoBehaviour
{
    [SerializeField]
    public int damage;
    // Start is called before the first frame update
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name.Equals("Fairy"))
        {
            Fairy.HealthPoint -= damage;
            SoundManagerScript.PlaySound("damage_take");
            if (Fairy.HealthPoint <= 0)
            {
                SceneManager.LoadScene("Lose");
            }
        }
    }
}
