using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraConroler : MonoBehaviour
{
    public float dumping=1.5f;
    public bool isLeft;
    private GameObject player;
  
    [SerializeField]
    private float leftLimit;
    [SerializeField]
    private float rightLimit;
    [SerializeField]
    private float upperLimit;
    [SerializeField]
    private float downLimit;



     private void Start() {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    private void Update() {

       Vector3 target = new Vector3(player.transform.position.x, player.transform.position.y, -9.7f);

       if (target.x > rightLimit)
        {
            target.x = rightLimit;
        }
        if (target.x < leftLimit)
        {
            target.x = leftLimit;
        }
        if (target.y > upperLimit)
        {
            target.y = upperLimit;
        }
        if (target.y < downLimit)
        {
            target.y = downLimit;
        }
        
        transform.position = Vector3.Lerp(transform.position, target, Time.deltaTime * dumping);
   
    }
    
}