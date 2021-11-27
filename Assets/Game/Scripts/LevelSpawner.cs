using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class RoadSegment{
	public GameObject segment;
	public int[] possibleFollowupSegments;
	public bool dontRecycle;
	
	List<GameObject> storage = new List<GameObject>();
	
	public bool HasStorage(){
		return storage.Count > 0;
	}
	
	public void AddToStorage(GameObject roadSegment){
		BuildTargetPoint[] buildTargets = roadSegment.GetComponentsInChildren<BuildTargetPoint>();
		
		for(int i = 0; i < buildTargets.Length; i++){
			buildTargets[i].TryRemoveItem();
		}
		
		roadSegment.SetActive(false);
		storage.Add(roadSegment);
	}
	
	public GameObject GetFromStorage(){
		GameObject roadSegment = storage[0];
		storage.Remove(roadSegment);
		roadSegment.SetActive(true);
		
		return roadSegment;
	}
}

public class LevelSpawner : MonoBehaviour {
    
	public RoadSegment[] segments;
	
	public int firstSegment;
	public Vector3 startPosition;
	public int startCount;
	
	public float worldSpeed;
	public float bounds;
	
	RoadSegmentController lastSpawned;
	
	bool gameStarted;
	
	void Start(){
		InitializeRoad();
	}
	
	void InitializeRoad(){
		for(int i = 0; i < startCount; i++){
			SpawnNew(firstSegment, i == 0);
		}
	}
	
	void SpawnNew(int randomIndex, bool first){
		Vector3 spawnPos = first ? startPosition : lastSpawned.transform.position + Vector3.forward * lastSpawned.size;
		
		if(randomIndex == -1){
			int[] possibleIndexes = segments[lastSpawned.GetIndex()].possibleFollowupSegments;
			randomIndex = possibleIndexes[Random.Range(0, possibleIndexes.Length)];
		}
		
		RoadSegment s = segments[randomIndex];
		GameObject newSegment = s.HasStorage() ? s.GetFromStorage() : Instantiate(s.segment);
		
		newSegment.transform.position = spawnPos;
		
		RoadSegmentController controller = newSegment.GetComponent<RoadSegmentController>();
		controller.Initialize(worldSpeed, this, bounds, randomIndex);
		
		lastSpawned = controller;
	}
	
	public void Cycle(GameObject target, int index){
		if(!segments[index].dontRecycle){
			segments[index].AddToStorage(target);
		}
		else{
			Destroy(target);
		}
		
		SpawnNew(gameStarted ? -1 : firstSegment, false);
	}
	
	public void StartSpawning(){
		gameStarted = true;
	}
}
