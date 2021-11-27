using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class NextScene : MonoBehaviour
{
    public int scene;
    public int second;
    void Start()
    {
        StartCoroutine(wait());
    
    }
    IEnumerator wait()
    {
        yield return new WaitForSeconds(second);
        SceneManager.LoadScene(scene);
       
    }

}
