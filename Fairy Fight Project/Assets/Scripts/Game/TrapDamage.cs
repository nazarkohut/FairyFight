using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TrapDamage : MonoBehaviour
{
    [SerializeField]
    int damage = 3;

    private void OnTriggerStay2D(Collider2D collider)
    {
        if (collider.gameObject.name.Equals("Fairy") && !Fairy.isAttacked)
        {         
            Fairy.HealthPoint -= damage;
            Fairy.DamageTake.Play();
            Debug.Log(Fairy.HealthPoint);
            Fairy.isAttacked = true;
            Task.Delay(1000).ContinueWith(t => { Fairy.isAttacked = false; });
            if (Fairy.HealthPoint <= 0) {
                SceneManager.LoadScene("Lose");
            }
        }
    }



}
