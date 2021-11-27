using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Screenshake : MonoBehaviour {
	
	public float duration;
	public float amount;
    
	public IEnumerator Shake(){
		if(PlayerPrefs.GetInt("Screenshake") != 1)
			yield break;
		
		yield return new WaitForSeconds(1f/5f);
		
		float elapsed = 0f;
		
		Vector3 pos = transform.position;
		
		while(elapsed < duration){
			transform.position += Random.insideUnitSphere.normalized * amount;
			
			elapsed += Time.deltaTime;
			
			yield return 0;
		}
		
		transform.position = pos;
	}
}
