using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class flycarcollider : MonoBehaviour
{
    public GameObject open1;
    public GameObject open2;
    public GameObject open3;
    public GameObject close1;
    public GameObject close2;
    public GameObject close3;
    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("ACTIVE trigger");
        if (collision.collider.name== "carcar")
        {
            open1.SetActive(true);
            open2.SetActive(true);
            open3.SetActive(true);
            close1.SetActive(false);
            close2.SetActive(false);
            close3.SetActive(false);
        }
    }



}
