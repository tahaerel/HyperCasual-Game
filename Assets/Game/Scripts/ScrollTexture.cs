using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollTexture : MonoBehaviour {
    
	public Material mat;
	public Vector2 scrollVector;
	public Vector2 pausedScrollVector;
	
	bool scrolling = true;
	
	void Start(){
		mat.mainTextureOffset = Vector2.zero;
	}
	
	void Update(){
		mat.mainTextureOffset += Time.deltaTime * (scrolling ? scrollVector : pausedScrollVector);
	}
	
	public void SetScrollState(bool scrolling){
		this.scrolling = scrolling;
	}
}
