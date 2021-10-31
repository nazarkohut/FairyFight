using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public class Boss : MonoBehaviour
{
    bool isAttacking = false;
    bool isAttacked = false;
    public int HealthPoint = 5;
    public int MaxHealthPoint = 5;

    public BoxCollider2D bodyCollider;

    public BoxCollider2D attackCollider;

    public Animator animator;

    public Rigidbody2D rb;
    [SerializeField]
    public GameObject hitBox;


    void Start()
    {
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        hitBox.SetActive(false);
    }
    IEnumerator DoAttack()
    {
        yield return new WaitForSeconds(0.8f);
        hitBox.SetActive(true);

        yield return new WaitForSeconds(0.7f);
        hitBox.SetActive(false);
        gameObject.GetComponent<Move>().enabled = true;
        isAttacking = false;
    }
    private void OnTriggerStay2D(Collider2D collider)
    {
        if (collider.gameObject.name.Equals("Fairy"))
        {
            if (!isAttacking)
            {
                isAttacking = true;
                gameObject.GetComponent<Move>().enabled = false;
                animator.Play("attack");
                StartCoroutine(DoAttack());
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.IsTouching(bodyCollider) && collision.gameObject.name.Equals("fairy_bullet(Clone)") && !isAttacked)
        {
            isAttacked = true;
            HealthPoint -= 1;
            if (HealthPoint == 0)
            {
                Destroy(gameObject);
                Fairy.HealthPoint += 10;
                Timer.currentTime += 20;
            }
            Task.Delay(400).ContinueWith(t =>
            {
                isAttacked = false;

            });
        }
    }

}
