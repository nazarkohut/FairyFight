using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyObjects : MonoBehaviour
{
    Vector2 pos;
    [SerializeField] Animator animator;

    [SerializeField] Object candy;
    
    // Start is called before the first frame update
    void Start()
    {
        pos=transform.position;
    }

    // Update is called once per frame
    void Update()
    {
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        if(collision.gameObject.name == "AttackHitBox"){
            // isShacking=true;
	    Debug.Log("dasasdads");
            animator.Play("destroy");
             Invoke("ExplodeTheObject",.3f);
        }
    }
    void ExplodeTheObject(){
        GameObject cand = (GameObject)Instantiate(candy);
        cand.transform.position = transform.position;
        Destroy(gameObject);
    }
}
