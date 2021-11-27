using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerDead : MonoBehaviour {
	
	public BuildTargetPoint buildTarget;
    
	void OnTriggerEnter(Collider other){
		if(buildTarget.HasItem())
			return;
		
		DogCat dogCat = other.gameObject.GetComponent<DogCat>();
		
		if(dogCat == null)
			return;
		
		dogCat.Die();
	}
}
