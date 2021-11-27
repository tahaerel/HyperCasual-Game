using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class deathsystemcar: MonoBehaviour
{
    public GameObject player;
    public GameObject canvas;


   private void OnTriggerEnter(Collider collision)
    {
        if (collision.tag == "citizen")
        {
            canvas.SetActive(true);
            player.GetComponent<SwipeMoveCar>().enabled = false;
            Debug.Log("CARPTİ");
        }
       
    }


}
