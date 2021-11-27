using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class SwipeMoveCar : MonoBehaviour {

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

        Vector3 sag_git = new Vector3(1.50f, transform.position.y, transform.position.z);
        Vector3 sol_git = new Vector3(-1.303f, transform.position.y, transform.position.z);

        if (Input.touchCount > 0)
        {
            Touch parmak = Input.GetTouch(0);
            if(parmak.deltaPosition.x>10.0f)
            {
                Debug.Log("saga dokundun");
                sag = true;
                sol = false;
            }
            if (parmak.deltaPosition.x < -10.0f)
            {
                Debug.Log("sola dokundun");
                sag = false;
                sol = true;
            }
            if (parmak.deltaPosition.y > 40.0f)
            {
                rigi.velocity = Vector3.zero;
                rigi.velocity = Vector3.up * ziplama;
            }
            if (sag == true)
            {
                transform.position = Vector3.Lerp(transform.position, sag_git, 1 * Time.deltaTime);


            }
            }
            if (sol == true)
            {
                transform.position = Vector3.Lerp(transform.position, sol_git, 1 * Time.deltaTime);


            }

            //sol -0.469
            // sag 0.482

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

