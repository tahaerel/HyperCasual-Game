using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveTruck : MonoBehaviour {
    
	public float speed;
	public float acceleration;
	public Transform trailer;
	
	bool moving;
	
	public void Move(){
		moving = true;
	}
	
	void Update(){
		if(!moving)
			return;
		
		speed += (speed * acceleration) * Time.deltaTime;
		
		transform.Translate(Vector3.right * Time.deltaTime * speed, Space.World);
		trailer.Translate(Vector3.right * Time.deltaTime * speed, Space.World);
	}
}
