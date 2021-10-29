using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraConroler : MonoBehaviour
{
    public float dumping=1.5f;
    public Vector2 offset= new Vector2(2f,1f);
    public bool isLeft;
    private Transform player;
    private float lastX;

    [SerializeField]
    private float leftLimit;
    [SerializeField]
    private float rightLimit;
    [SerializeField]
    private float upperLimit;
    [SerializeField]
    private float downLimit;





     private void Start() {
         offset = new Vector2(Mathf.Abs(offset.x),offset.y);
         FindPlayer(isLeft);
    }
    public void FindPlayer(bool playerIsLeft){
        player=GameObject.FindGameObjectWithTag("Player").transform;

        lastX = Mathf.RoundToInt(player.position.x);
        if (playerIsLeft){
            transform.position=new Vector3(player.position.x - offset.x,player.position.y - offset.y,transform.position.z);
        }else{
            transform.position=new Vector3(player.position.x + offset.x,player.position.y + offset.y,transform.position.z);
        }
    }   
        private void Update() {
            if(player){
                int curentX = Mathf.RoundToInt(player.position.x);
                if(curentX > lastX) isLeft = false;
                else if(curentX < lastX) isLeft = true;
                lastX = Mathf.RoundToInt(player.position.x);

                Vector3 target;
                if( isLeft){
                    target = new Vector3(player.position.x - offset.x,player.position.y - offset.y,transform.position.z);
                }else{
                    target = new Vector3(player.position.x + offset.x,player.position.y + offset.y,transform.position.z);
                }
                Vector3 curentPosition = Vector3.Lerp(transform.position,target,dumping*Time.deltaTime);
                transform.position=curentPosition; 
            }
            transform.position = new Vector3(
                Mathf.Clamp(transform.position.x,leftLimit,rightLimit),
                Mathf.Clamp(transform.position.y,upperLimit,downLimit),
                transform.position.z
            );
        }
    
}
