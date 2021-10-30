using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AssassinHPbar : MonoBehaviour
{
    Vector3 localScale;
    public Assassin assassin;
    Vector3 startLocalScale;

    // Start is called before the first frame update
    void Start()
    {
        localScale = transform.localScale;
        startLocalScale = transform.localScale;
    }

    // Update is called once per frame
    void Update()
    {
        localScale.x = ((float)assassin.HealthPoint / (float)assassin.MaxHealthPoint) * (float)startLocalScale.x;
        transform.localScale = localScale;
    }
}
