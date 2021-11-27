using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreeSpawner : MonoBehaviour {
    
	//visible in inspector
	public Vector3 range;
	public GameObject[] trees;
	
	public int minTrees;
	public int maxTrees;
	
	public float minScale;
	public float maxScale;
	
	void Start(){
		int treeCount = Random.Range(minTrees, maxTrees);
		
		for(int i = 0; i < treeCount; i++){
			Vector3 pos = transform.position + new Vector3(Random.Range(-range.x, range.x), 0, Random.Range(-range.z, range.z));
			GameObject newTree = Instantiate(trees[Random.Range(0, trees.Length)], pos, transform.rotation);
			
			newTree.transform.Rotate(Vector3.up * Random.Range(0, 360));
			newTree.transform.localScale *= Random.Range(minScale, minScale);
			
			newTree.transform.SetParent(transform, true);
		}
	}
}
