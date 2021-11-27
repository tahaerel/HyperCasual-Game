using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCars : MonoBehaviour {
    
	public float speed;
	public float range;
	
	void Update(){
		transform.Translate(Vector3.right * speed * Time.deltaTime, Space.World);
		
		if(transform.position.x < -range)
			transform.position += Vector3.right * range * 2f;
		
		if(transform.position.x > range)
			transform.position -= Vector3.right * range * 2f;
	}
}
