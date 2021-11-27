using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class endlevel : MonoBehaviour
{
    public int scene;

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.tag == "Player")
        {
            SceneManager.LoadScene(scene);
        }
        
    }


}
