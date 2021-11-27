using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoadSegmentController : MonoBehaviour {
    
	public float size;
	
	bool move = true;
	
	LevelSpawner spawner;
	
	float speed;
	float bounds;
	
	int index;
	
	void Update(){
		if(move)
			transform.Translate(Vector3.forward * -Time.deltaTime * speed);
	}
	
	void LateUpdate(){
		if(transform.position.z < bounds)
			spawner.Cycle(gameObject, index);
	}
	
	public void Initialize(float speed, LevelSpawner spawner, float bounds, int segmentIndex){
		this.speed = speed;
		this.spawner = spawner;
		this.bounds = bounds;
		this.index = segmentIndex;
	}
	
	public int GetIndex(){
		return index;
	}
	
	public void SetMoveState(bool move){
		this.move = move;
	}
}
