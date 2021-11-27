using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pausebutton : MonoBehaviour
{
    public GameObject pausemenu;
   public void pause()
    {
        pausemenu.SetActive(true);
        Time.timeScale = 0f;

    }
    public void resume()
    {
        pausemenu.SetActive(false);
        Time.timeScale = 1f;

    }
}
