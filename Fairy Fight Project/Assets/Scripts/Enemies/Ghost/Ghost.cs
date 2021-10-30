using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Ghost : MonoBehaviour
{
    public Animator animator;
    [SerializeField]
    GameObject attackBullet;

    bool isAttacking = false;

    public static int HealthPoint = 2;

    public CircleCollider2D attackCollider;
    public BoxCollider2D bodyCollider;

    void Start()
    {
        animator = GetComponent<Animator>();
        attackBullet.SetActive(false);
    }
    IEnumerator DoAttack()
    {
        yield return new WaitForSeconds(.15f);

        GameObject bullet = (GameObject)Instantiate(attackBullet);
        bullet.transform.position = new Vector3(transform.position.x , transform.position.y + 0.4f, transform.position.z);
        bullet.transform.localScale = new Vector3(5, 5, 5);
        bullet.SetActive(true);
        yield return new WaitForSeconds(.60f);
        Destroy(bullet);
        yield return new WaitForSeconds(.30f);
        isAttacking = false;
    }

    private void OnTriggerStay2D(Collider2D collider)
    {
        if (collider.gameObject.name.Equals("Fairy")){
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
        if (collision.IsTouching(bodyCollider) && collision.gameObject.name.Equals("fairy_bullet(Clone)"))
        {
            Debug.Log("here");
            HealthPoint -= 1;
            if (HealthPoint <= 0)
            {
                SceneManager.LoadScene("Lose");
            }
        }
    }

}
