using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class retry : MonoBehaviour
{
   public int scene;
    public void tekrar()
    {
        SceneManager.LoadScene(scene);

    }
    
}
