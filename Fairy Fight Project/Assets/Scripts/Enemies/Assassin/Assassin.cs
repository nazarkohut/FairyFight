using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public class Assassin : MonoBehaviour
{
    bool isAttacking = false;

    public int HealthPoint = 3;
    public int MaxHealthPoint = 3;

    public BoxCollider2D bodyCollider;

    public BoxCollider2D attackCollider;

    public Animator animator;
    bool isAttacked = false;
    [SerializeField]
    public GameObject hitBox;

    void Start()
    {
        animator = GetComponent<Animator>();
    }
    IEnumerator DoAttack()
    {
        yield return new WaitForSeconds(.20f);
        hitBox.SetActive(true);

        yield return new WaitForSeconds(.30f);
        hitBox.SetActive(false);

        isAttacking = false;
    }
    private void OnTriggerStay2D(Collider2D collider)
    {
        if (collider.gameObject.name.Equals("Fairy"))
        {
            if (!isAttacking)
            {
                isAttacking = true;
                animator.Play("attack");
                StartCoroutine(DoAttack());
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.IsTouching(bodyCollider) && collision.gameObject.name.Equals("fairy_bullet(Clone)")&&!isAttacked)
        {
            isAttacked = true;
            HealthPoint -= 1;
            if (HealthPoint == 0)
            {
                Destroy(gameObject);
                Fairy.HealthPoint += 1;
                Timer.currentTime += 5;
            }
            Task.Delay(400).ContinueWith(t =>
            {
                isAttacked = false;

            });
        }
    }
}
