using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class MoneyUp : MonoBehaviour
{
    public Text moneyshow;
    Money mani;
    public GameObject obje;

    void Start()
        
    {
        mani = obje.GetComponent<Money>(); 
        Debug.Log(mani.para);

    }
     private void OnTriggerEnter(Collider collision)
        {

            if (collision.tag == "money")
            {
                Debug.Log("money");
                mani.para++;
                Destroy(collision.gameObject);
                moneyshow.text = mani.para + " / 12";
            }

        }
     
}
