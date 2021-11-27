using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlaceEffect : MonoBehaviour {
    
	public UnityEvent placeEvent;
	
	public void TriggerPlaceEffect(){
		placeEvent.Invoke();
	}
}
