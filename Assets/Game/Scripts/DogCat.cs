using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DogCat : MonoBehaviour {
	
	public float checkRadius;
	public LayerMask layerMask;
	public float fallForce;
	
	public GameObject splash;
	public GameObject blood;
	
	public GameObject dust;
	
	Rigidbody rb;
	MoveEffect moveEffect;
	
	bool showedSplash;
	
	GameManager manager;
	
	Collider col;
	
	void Start(){
		rb = GetComponent<Rigidbody>();
		moveEffect = GetComponent<MoveEffect>();
		col = GetComponent<Collider>();
		
		manager = FindObjectOfType<GameManager>();
	}
    
	void LateUpdate(){
		RaycastHit hit;
		
		if(!Physics.SphereCast(transform.position + Vector3.up * 10, checkRadius, -Vector3.up, out hit, Mathf.Infinity, layerMask) && rb.isKinematic){
			rb.isKinematic = false;
			moveEffect.enabled = false;
			
			rb.AddForce(Vector3.up * -fallForce);
		}
		
		if(transform.position.y < -5.3f && !showedSplash){
			showedSplash = true;
			
			Instantiate(splash, transform.position, splash.transform.rotation);
			
			if(dust != null)
				dust.SetActive(false);
			
			manager.PetDied();
		}
	}
	
	public void Die(){
		if(dust != null)
			dust.SetActive(false);
		
		col.enabled = false;
		
		Instantiate(blood, transform.position, splash.transform.rotation);
		
		manager.PetDied();
		
		Destroy(gameObject);
	}
}
