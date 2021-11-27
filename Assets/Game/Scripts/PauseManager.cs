using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseManager : MonoBehaviour {
	
	public Animator dog;
	public Animator cat;
	
	public ParticleSystem[] particles;
	
	GameManager manager;
	
	void Start(){
		manager = GetComponent<GameManager>();
	}
    
	public void PauseAll(bool paused){
		PauseAnimator(dog, paused);
		PauseAnimator(cat, paused);
		
		RoadSegmentController[] controllers = FindObjectsOfType<RoadSegmentController>();
		
		for(int i = 0; i < controllers.Length; i++){
			controllers[i].SetMoveState(!paused);
		}
		
		ScrollTexture[] scrollEffects = FindObjectsOfType<ScrollTexture>();
		
		for(int i = 0; i < scrollEffects.Length; i++){
			scrollEffects[i].SetScrollState(!paused);
		}
		
		MoveEffect[] moveEffects = FindObjectsOfType<MoveEffect>();
		
		for(int i = 0; i < moveEffects.Length; i++){
			moveEffects[i].SetMoveState(!paused);
		}
		
		manager.Pause(paused);
		
		foreach(ParticleSystem particlesystem in particles){
			if(paused && particlesystem.isPlaying){
				particlesystem.Stop();
			}
			else if(!paused && !particlesystem.isPlaying){
				particlesystem.Play();
			}
		}
	}
	
	void PauseAnimator(Animator anim, bool paused){
		if(anim == null)
			return;
		
		anim.speed = paused ? 0 : 1;
	}
}
