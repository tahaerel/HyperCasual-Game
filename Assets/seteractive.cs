using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class seteractive : MonoBehaviour
{
    public GameObject main;
    public GameObject levelselect;
   public void setac()
    {

        levelselect.SetActive(true);
        main.SetActive(false);

    }


}
