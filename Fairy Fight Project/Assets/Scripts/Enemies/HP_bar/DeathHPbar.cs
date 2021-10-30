using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathHPbar : MonoBehaviour
{
    Vector3 localScale;
    public Death death;
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
        localScale.x = ((float)death.HealthPoint / (float)death.MaxHealthPoint) * (float)startLocalScale.x;
        transform.localScale = localScale;
    }
}
