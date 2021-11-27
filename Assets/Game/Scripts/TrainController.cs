using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrainController : MonoBehaviour {
	
	public float bounds;
    
	public float speed;
	public float rotateSpeed;
	
	public float switchPointX;
	public BuildTargetPoint buildTarget;
	
	float moveDirection = -1f;
	
	bool deactivated;
	
	void Update(){
		if(deactivated)
			return;
		
		transform.Translate(Vector3.right * Time.deltaTime * speed * moveDirection, Space.World);
		
		if(moveDirection == 0){
			transform.Rotate(Vector3.up * Time.deltaTime * rotateSpeed, Space.World);
			
			if(transform.localEulerAngles.y >= 180)
				moveDirection = 1f;
		}
		
		if(transform.position.x < switchPointX && transform.position.x > switchPointX - 0.75f && moveDirection == -1f && buildTarget.HasItem()){
			moveDirection = 0;
		}
		
		if(transform.localPosition.x <= -bounds){
			transform.Translate(Vector3.right * bounds * 2, Space.World);
		}
		
		if(transform.position.x > bounds)
			deactivated = true;
	}
	
	void OnTriggerEnter(Collider other){
		if(buildTarget.HasItem())
			return;
		
		DogCat dogCat = other.gameObject.GetComponent<DogCat>();
		
		if(dogCat == null)
			return;
		
		dogCat.Die();
	}
}
