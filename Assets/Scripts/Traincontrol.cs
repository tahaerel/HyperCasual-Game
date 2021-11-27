using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Traincontrol : MonoBehaviour
{
    public GameObject righttrain;
    public GameObject lefttrain;
    public GameObject middletrain;
	int line = 0;


    string sceneName;

    public void goleft()
    {
        line--;
        if (line == -1)
        {
            line = -1;
            lefttrain.SetActive(true);
            middletrain.SetActive(false);
            righttrain.SetActive(false);
        }
        else if (line == 0)
        {
            middletrain.SetActive(true);
            righttrain.SetActive(false);
            lefttrain.SetActive(false);
        }
    }

    public void goright()
    {
        line++;
        if (line == 1)
        { line = 1;
            righttrain.SetActive(true);
            middletrain.SetActive(false);
            lefttrain.SetActive(false);
        }
        else if (line == 0)
        {
            middletrain.SetActive(true);
            righttrain.SetActive(false);
            lefttrain.SetActive(false);
        }
    }



}