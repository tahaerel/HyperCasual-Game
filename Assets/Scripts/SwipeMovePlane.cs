using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class SwipeMovePlane : MonoBehaviour {

    int money = 0;
    public Text moneyshow;
    Rigidbody rigi;
    bool sol;
    bool sag;
    float hiz = 2.0f;
    float ziplama = 0.0f;

    string sceneName;



    void Start()
    {
        Scene currentScene = SceneManager.GetActiveScene();
 
        sceneName = currentScene.name;
        Debug.Log(sceneName);
        rigi = GetComponent<Rigidbody>();

    }
    void Update()
    {
        transform.Translate(0, 0, hiz * Time.deltaTime);

    

        if (Input.touchCount > 0)
        {
            Touch parmak = Input.GetTouch(0);
           
            if (parmak.deltaPosition.y > 40.0f)
            {
                rigi.velocity = Vector3.zero;
                rigi.velocity = Vector3.up * ziplama;
            }

            //sol -0.469
            // sag 0.482

        }
    }

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.tag == "money")
        {
            Debug.Log("money");
            money=money+1;
            Destroy(collision.gameObject);

            if(sceneName == "ep1")
            moneyshow.text = money + " /3";
            else if(sceneName == "ep2")
            moneyshow.text = money + " /8";
        }

    }

}

