using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveEffect : MonoBehaviour {
	
	public float speed;
	public float amplitude;
	

	Vector3 pos;
	
	float timer;
	
	bool move = true;
	
	void Start(){
		pos = transform.localPosition;
	}
    
	void Update(){
		if(!move)
			return;
		
		timer += Time.deltaTime;
		transform.localPosition = pos + Vector3.forward * Mathf.Sin(timer * speed) * amplitude;
	}
	
	public void SetMoveState(bool move){
		this.move = move;
	}
}
