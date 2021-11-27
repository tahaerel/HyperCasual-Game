using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class trainmoney : MonoBehaviour
{
    public Text moneyshow;
    int money = 0;
    private void OnTriggerEnter(Collider collision)
    {
        if (collision.tag == "money")
        {
            Debug.Log("money");
            money++;
            Destroy(collision.gameObject);
            moneyshow.text = money + " /12";
        }

    }
}
