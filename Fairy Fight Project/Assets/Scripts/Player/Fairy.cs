using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Fairy : MonoBehaviour
{
    public Animator animator;
   
    [SerializeField]
    public int velocity;

    [SerializeField]
    GameObject attackBullet;
    [SerializeField] 
    Text HPbar;

    private BoxCollider2D boxCollider;


    private Vector3 moveDelta;
    bool isAttacking = false;

    [SerializeField]
    public static int HealthPoint = 100;

    public static bool isAttacked;

    public static bool isRight = true;

    private void Start()
    {
        boxCollider = GetComponent<BoxCollider2D>();
        animator = GetComponent<Animator>();
        attackBullet.SetActive(false);
        isAttacked = false;

    }

    IEnumerator DoAttack()
    {
        yield return new WaitForSeconds(.38f);
        GameObject bullet = (GameObject)Instantiate(attackBullet);
        if(isRight)
            bullet.transform.position = new Vector3(transform.position.x + 1.5f, transform.position.y - 0.4f, transform.position.z);
        else
            bullet.transform.position = new Vector3(transform.position.x - 1.5f, transform.position.y - 0.4f, transform.position.z);
 

        bullet.transform.localScale = new Vector3(5, 5, 5);
        bullet.SetActive(true);
        yield return new WaitForSeconds(.5f);
        Destroy(bullet);
        isAttacking = false;
    }
    private void Update()
    {
        if (Input.GetButtonDown("Fire1") && !isAttacking)
        {
            isAttacking = true;
            animator.Play("shoot");

            StartCoroutine(DoAttack());
        }
        HPbar.text = HealthPoint.ToString();
    }

    private void FixedUpdate()
    {
        moveDelta = Vector3.zero;

        float x = Input.GetAxisRaw("Horizontal");
        float y = Input.GetAxisRaw("Vertical");

        moveDelta = new Vector3(x * velocity, y * velocity, 0);


        if (moveDelta.x < 0)
        {
            transform.localScale = new Vector3(Math.Abs(transform.localScale.x), transform.localScale.y, transform.localScale.z);
            isRight = false;
        }
        else if (moveDelta.x > 0)
        {
            transform.localScale = new Vector3(Math.Abs(transform.localScale.x) * -1, transform.localScale.y, transform.localScale.z);
            isRight = true;
        }

        transform.Translate(moveDelta * Time.deltaTime);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.IsTouching(boxCollider) && collision.gameObject.tag.Equals("bullet"))
        {
            HealthPoint -= 1;
            if (HealthPoint <= 0)
            {
                SceneManager.LoadScene("Lose");
            }
        }
    }

}