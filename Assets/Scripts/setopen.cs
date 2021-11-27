using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class setopen : MonoBehaviour
{
    public GameObject open;

    private void OnTriggerEnter(Collider collision)
    {
       
        if (collision.tag == "Player")
        {
            open.SetActive(true);
        }
        
    }

}
