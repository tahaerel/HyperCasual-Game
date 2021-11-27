using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class planecontroller : MonoBehaviour
{


   private Touch touch;
   private Vector2 touchPosition;
   private Quaternion rotationX;

   private float rotateSpeedModifier = 0.1f;

   void Update()
   {
       if(Input.touchCount>=0)
       {
           touch = Input.GetTouch(0);
           if (touch.phase == TouchPhase.Moved)
           {
               rotationX = Quaternion.Euler(
                  touch.deltaPosition.x * rotateSpeedModifier,
                  -0f,
                  0f);
               transform.rotation = rotationX * transform.rotation;
           }

       }

   }


}
