using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlignToGround : MonoBehaviour {
	
	public LayerMask layerMask;
	
	public Transform front;
	public Transform back;
	
	public float rotationSensitivity;
	
	float rot;
    
	void LateUpdate(){
		Vector3 rayStart = transform.position + Vector3.up * 30f;
		
		RaycastHit hit;
		
		if(Physics.Raycast(rayStart, -Vector3.up, out hit, Mathf.Infinity, layerMask))
			transform.position = hit.point;
		
		Rotate();
	}
	
	void Rotate(){
		float frontHeight = GetHeight(front);
		float backHeight = GetHeight(back);
		
		rot = (frontHeight - backHeight) * rotationSensitivity;	
		
		transform.localEulerAngles = new Vector3(transform.localEulerAngles.x, transform.localEulerAngles.y, rot);
	}
	
	float GetHeight(Transform t){
		Vector3 start = t.position + Vector3.up * 30f;
		
		RaycastHit hit;
		
		if(Physics.Raycast(start, -Vector3.up, out hit, Mathf.Infinity, layerMask))
			return hit.point.y;
		
		return t.position.y;
	}
	
	void OnTriggerEnter(Collider other){
		DogCat dogCat = other.gameObject.GetComponent<DogCat>();
		
		if(dogCat == null)
			return;
		
		dogCat.Die();
	}
}
