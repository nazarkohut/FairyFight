using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public class Slime : MonoBehaviour
{
    bool isAttacking = false;

    public int HealthPoint = 5;

    public BoxCollider2D bodyCollider;

    void Start()
    {
        bodyCollider = gameObject.GetComponent<BoxCollider2D>();
    }

    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.IsTouching(bodyCollider) && collision.gameObject.name.Equals("fairy_bullet(Clone)"))
        {
            Debug.Log("here");
            HealthPoint -= 1;
            if (HealthPoint <= 0)
            {
                Destroy(gameObject);
            }
        }
        if (collision.gameObject.name.Equals("Fairy")&&!isAttacking)
        {
            isAttacking = true;
            Fairy.HealthPoint -= 3; 
            Task.Delay(1000).ContinueWith(t => { 
                isAttacking = false;
             
            });
        }
    }
}
