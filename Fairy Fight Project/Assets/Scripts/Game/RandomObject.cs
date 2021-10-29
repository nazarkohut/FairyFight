using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomObject : MonoBehaviour
{

    public GameObject[] DecorObject;
   

    void Start()
    {
        Instantiate(DecorObject[Random.Range(0, DecorObject.Length)], transform.position, Quaternion.identity);
        Destroy(gameObject);
    }
}
