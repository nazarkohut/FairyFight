using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fairy : MonoBehaviour
{
    public Animator animator;
   
    [SerializeField]
    int velocity;

    [SerializeField]
    GameObject attackHitBox;

    private BoxCollider2D boxCollider;

    private RaycastHit2D hit;

    private Vector3 moveDelta;
    bool isAttacking = false;



    private void Start()
    {
        boxCollider = GetComponent<BoxCollider2D>();
        animator = GetComponent<Animator>();
        attackHitBox.SetActive(false);
    }

    IEnumerator DoAttack()
    {
        attackHitBox.SetActive(true);
        yield return new WaitForSeconds(.2f);
        attackHitBox.SetActive(false);

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
    }

    private void FixedUpdate()
    {
        //reset MoveDelta
        moveDelta = Vector3.zero;

        // start_local_scale=transform.localScale;

        float x = Input.GetAxisRaw("Horizontal");
        float y = Input.GetAxisRaw("Vertical");

        moveDelta = new Vector3(x * velocity, y * velocity, 0);


        //swap sprite direction , wether you ging right or left
        if (moveDelta.x < 0)
        {
            transform.localScale = new Vector3(Math.Abs(transform.localScale.x), transform.localScale.y, transform.localScale.z);
        }
        else if (moveDelta.x > 0)
            transform.localScale = new Vector3(Math.Abs(transform.localScale.x) * -1, transform.localScale.y, transform.localScale.z);


        transform.Translate(moveDelta * Time.deltaTime);

    }
}