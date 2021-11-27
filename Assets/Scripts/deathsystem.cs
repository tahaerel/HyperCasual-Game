using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class deathsystem : MonoBehaviour
{
    public GameObject player;
    public GameObject canvas;
    [SerializeField] private Animator myanimator;


   private void OnTriggerEnter(Collider collision)
    {
        if (collision.tag == "citizen")
        {
            canvas.SetActive(true);
            myanimator.SetBool("death", true);
            player.GetComponent<SwipeMove>().enabled = false;
            Debug.Log("CARPTİ");
        }
       
    }


}
