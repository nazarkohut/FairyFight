using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField]
    public float speed;

    public  Vector3 way;
    void Start()
    {
        if(Fairy.isRight)
            way = new Vector3(1, Input.GetAxisRaw("Vertical"), 1);
        else
            way = new Vector3(-1, Input.GetAxisRaw("Vertical"), 1);
    }
    
    private void Update()
    {   
        gameObject.GetComponent<Rigidbody2D>().velocity = transform.TransformDirection(speed, 0,0);    
        gameObject.GetComponent<Rigidbody2D>().transform.right = way ;
    }

}
