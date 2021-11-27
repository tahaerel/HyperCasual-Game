using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

[System.Serializable]
public class Item{
	public GameObject buildItem;
	public Vector3 arrowOffset;
}

public class BuildManager : MonoBehaviour {
    
	public Item[] buildItems;
	public LayerMask layerMask;
	public float snapSize;
	public float acceptRange;
	
	public Transform arrows;
	public Image arrowsImage;
	public Color validColor;
	public Color invalidColor;
	
	public AudioSource plopSound;
	public AudioSource buttonSound;
	
	GameObject currentItem;
	int currentItemIndex;
	
	RaycastHit hit;
	
	BuildTargetPoint[] buildTargets;
	
	GameManager manager;
	PauseManager pauseManager;
	Screenshake screenshake;
	
	Vector3 lastPos;
	
	public void BuildItem(int buildIndex){
		GameObject item = buildItems[buildIndex].buildItem;
		
		currentItem = Instantiate(item);
		currentItemIndex = buildIndex;
		
		pauseManager.PauseAll(true);
		
		buildTargets = FindObjectsOfType<BuildTargetPoint>();
		
		arrows.gameObject.SetActive(true);
		
		arrowsImage.color = invalidColor;
		
		
		buttonSound.Play();
	}
	
	void Start(){
		manager = FindObjectOfType<GameManager>();
		pauseManager = FindObjectOfType<PauseManager>();
		screenshake = FindObjectOfType<Screenshake>();
		
		arrows.gameObject.SetActive(false);
	}
	
	void Update(){
		if(Input.GetMouseButtonUp(0) && currentItem != null)
			TryPlaceItem();
	}
	
	void LateUpdate(){
		if(currentItem != null)
			UpdateCurrentItem();
	}
	
	void UpdateCurrentItem(){
		Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
		
		if(Physics.Raycast(ray, out hit, Mathf.Infinity, layerMask)){
			Vector3 pos = hit.point;
			
			pos -= Vector3.one;
			pos /= snapSize;
				
			pos = new Vector3(Mathf.Round(pos.x), pos.y, Mathf.Round(pos.z));
				
			pos *= snapSize;
			pos += Vector3.one;
			
			currentItem.transform.position = pos;
		}
		
		TrySnapItem();
		
		arrows.position = currentItem.transform.position + buildItems[currentItemIndex].arrowOffset;
		
		if(currentItem.transform.position != lastPos && !plopSound.isPlaying)
			plopSound.Play();
		
		lastPos = currentItem.transform.position;
	}
	
	void TrySnapItem(){
		bool snappedInPlace = false;
		
		for(int i = 0; i < buildTargets.Length; i++){
			if(buildTargets[i].buildItemIndex != currentItemIndex || buildTargets[i].HasItem())
				continue;
			
			if(Vector3.Distance(currentItem.transform.position, buildTargets[i].transform.position) < acceptRange){
				currentItem.transform.position = buildTargets[i].transform.position;
				
				snappedInPlace = true;
			}
		}
		
		arrowsImage.color = snappedInPlace ? validColor : invalidColor;
	}
	
	void TryPlaceItem(){
		pauseManager.PauseAll(false);
		
		bool placedItem = false;
		
		for(int i = 0; i < buildTargets.Length; i++){
			if(buildTargets[i].buildItemIndex != currentItemIndex || buildTargets[i].HasItem())
				continue;
			
			if(Vector3.Distance(currentItem.transform.position, buildTargets[i].transform.position) < acceptRange){
				currentItem.transform.SetParent(buildTargets[i].transform, false);
				currentItem.transform.localPosition = Vector3.zero;
				currentItem.transform.localEulerAngles = Vector3.zero;
				
				buildTargets[i].AssignItem(currentItem);
				
				currentItem.GetComponentInChildren<Animator>().SetTrigger("Place");
				
				StartCoroutine(screenshake.Shake());
				
				placedItem = true;
			}
		}
		
		if(!placedItem)
			Destroy(currentItem);
		
		currentItem = null;
		arrows.gameObject.SetActive(false);
	}
}
