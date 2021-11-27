using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class transform_walk : MonoBehaviour
{
    public float speed;
    Vector3 tempos;

    void Update()
    {
        tempos = transform.position;
        tempos.x += speed;
        transform.position = tempos;
    }
}
