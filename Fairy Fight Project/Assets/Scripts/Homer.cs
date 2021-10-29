using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;


public class Homer : MonoBehaviour
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




    private void Start() {
        boxCollider = GetComponent<BoxCollider2D>();
        animator = GetComponent<Animator>();
        attackHitBox.SetActive(false);
    }

    IEnumerator DoAttack(){
        attackHitBox.SetActive(true);
        yield return new WaitForSeconds(.2f);
        attackHitBox.SetActive(false);

        isAttacking=false;
    }
     private void Update() {
        if(Input.GetButtonDown("Fire1")&& !isAttacking ){
                isAttacking=true;
                animator.Play("attack");

               StartCoroutine(DoAttack());
        }
    }

    private void FixedUpdate() {
        //reset MoveDelta
        moveDelta = Vector3.zero;
        // start_local_scale=transform.localScale;

        float x = Input.GetAxisRaw("Horizontal");
        float y = Input.GetAxisRaw("Vertical");

        moveDelta = new Vector3(x*velocity,y*velocity,0);

        animator.SetFloat("Velocity",Mathf.Abs(x)+Mathf.Abs(y));


        //swap sprite direction , wether you ging right or left
        if(moveDelta.x>0){
            transform.localScale=new Vector3(Math.Abs(transform.localScale.x),transform.localScale.y,transform.localScale.z);
        }
        else if(moveDelta.x<0)
            transform.localScale = new Vector3(Math.Abs(transform.localScale.x)*-1,transform.localScale.y,transform.localScale.z);
        
        
        transform.Translate(moveDelta*Time.deltaTime); 

      









        // hit = Physics2D.BoxCast(transform.position,boxCollider.size,0,new Vector2(0,moveDelta.y),Mathf.Abs(moveDelta.y*Time.deltaTime),LayerMask.GetMask("Actor","Blocking"));
       
        // if(hit.collider==null){
        //     transform.Translate(0,moveDelta.y*Time.deltaTime,0); 
        // }
        
        // hit = Physics2D.BoxCast(transform.position,boxCollider.size,0,new Vector2(moveDelta.x,0),Mathf.Abs(moveDelta.x*Time.deltaTime),LayerMask.GetMask("Actor","Blocking"));
       
        // if(hit.collider==null){
        //     transform.Translate(moveDelta.x*Time.deltaTime,0,0); 
        // }
       
    }
}
