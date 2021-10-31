using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public class Death : MonoBehaviour
{
    bool isAttacking = false;
    bool isAttacked = false;
    public int HealthPoint = 5;
    public int MaxHealthPoint = 5;

    public BoxCollider2D bodyCollider;

    public BoxCollider2D attackCollider;

    public Animator animator;

    [SerializeField]
    public GameObject hitBox;

    void Start()
    {
        animator = GetComponent<Animator>();
    }
    IEnumerator DoAttack()
    {
        yield return new WaitForSeconds(.19f);
        hitBox.SetActive(true);

        yield return new WaitForSeconds(.22f);
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
        if (collision.IsTouching(bodyCollider) && collision.gameObject.name.Equals("fairy_bullet(Clone)") && !isAttacked)
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
