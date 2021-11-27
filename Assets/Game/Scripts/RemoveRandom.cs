using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RemoveRandom : MonoBehaviour {
    
	public int chance;
	
	public float minSize;
	public float maxSize;
	
	void Start(){
		if(Random.Range(0, chance) != 0){
			Destroy(gameObject);
		}
		else{
			transform.localScale *= Random.Range(minSize, maxSize);
		}
	}
}
