using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlimeHPbar : MonoBehaviour
{
    Vector3 localScale;
    public Slime slime;
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
        localScale.x = ((float)slime.HealthPoint / (float)slime.MaxHealthPoint) * (float)startLocalScale.x;
        transform.localScale = localScale;
    }
}