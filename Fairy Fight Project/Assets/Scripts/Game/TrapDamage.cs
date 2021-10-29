using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrapDamage : MonoBehaviour
{
    [SerializeField]
    int damage = 3;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name.Equals("Fairy")){
            //Homer.Damage_to_main_hero();
        }
    }



}
