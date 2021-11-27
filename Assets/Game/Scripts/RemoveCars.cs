using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RemoveCars : MonoBehaviour {
    
	public List<GameObject> cars;
	public int minRemove;
	public int maxRemove;
	
	void Start(){
		int removeCount = Random.Range(minRemove, maxRemove);
		
		for(int i = 0; i < removeCount; i++){
			int random = Random.Range(0, cars.Count);
			
			GameObject car = cars[random];
			cars.Remove(car);
			
			Destroy(car);
		}
	}
}
