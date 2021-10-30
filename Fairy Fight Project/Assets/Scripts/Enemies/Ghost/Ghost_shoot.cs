using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ghost_shoot : MonoBehaviour
{
    [SerializeField]
    public float speed=10;

    Vector3 way;
    void Start()
    {
        way = GameObject.FindGameObjectWithTag("Player").transform.position - transform.position;
        float lenght = Mathf.Sqrt(way.x * way.x + way.y * way.y + way.z * way.z);
        way = new Vector3(way.x / lenght, way.y / lenght, way.z / lenght);
    }
    private void Update()
    {
        gameObject.GetComponent<Rigidbody2D>().velocity = transform.TransformDirection(speed, 0, 0);
        gameObject.GetComponent<Rigidbody2D>().transform.right = way;
    }
}
