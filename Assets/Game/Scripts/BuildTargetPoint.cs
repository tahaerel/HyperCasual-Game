using System.Collections;
using System.Collections.Generic;
using UnityEngine.Events;
using UnityEngine;

public class BuildTargetPoint : MonoBehaviour {
    
	public int buildItemIndex;
	public UnityEvent assignItemEvent;
	
	GameObject item;
	
	public void AssignItem(GameObject item){
		this.item = item;
		
		assignItemEvent.Invoke();
	}
	
	public void TryRemoveItem(){
		if(item != null){
			Destroy(item);
		}
	}
	
	public bool HasItem(){
		return item != null;
	}
}
