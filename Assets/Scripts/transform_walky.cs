using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class transform_walky : MonoBehaviour
{
    public float speed;
    Vector3 tempos;

    void Update()
    {
        tempos = transform.position;
        tempos.z += speed;
        transform.position = tempos;
    }
}
