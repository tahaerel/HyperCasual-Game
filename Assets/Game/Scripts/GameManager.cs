using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine;

public class GameManager : MonoBehaviour {
	
	//visible in inspector
	public Animator startPanel;
	public Animator gamePanel;

	public Animator gameOverPanel;
	public Animator settings;
	
	public Animator transition;
	
	public List<Animator> hearts;
	public Text distanceLabel;
	
	public float dogSpeed = 8.8f;
	
	public Text distText;
	public Text bestText;
	
	public Toggle screenshakeToggle;
	public Toggle musicToggle;
	
	public AudioSource buttonAudio;
	public AudioSource tipSound;
	public AudioSource deathSound;
	public AudioSource backgroundLoop;
	
	//not in inspector
	float meters;
	
	bool paused;
	
	int petCount = 1;
	
	LevelSpawner levelSpawner;
	
	void Start(){
		//get level spawner
		levelSpawner = FindObjectOfType<LevelSpawner>();
		StartGame();
		//check if screenshake toggle should be enabled
		screenshakeToggle.isOn = PlayerPrefs.GetInt("Screenshake") == 1;
		StartGame();
		//check if background music should be enabled
		bool backgroundMusic = PlayerPrefs.GetInt("Music") == 0;
		musicToggle.isOn = backgroundMusic;
		
		//play music if it's enabled
		if(backgroundMusic)
			backgroundLoop.Play();

	
	}
	
	void Update(){
		//update distance
		if(!paused && gamePanel.GetBool("Show")){
			meters += Time.deltaTime * dogSpeed;
			distanceLabel.text = (int)meters + "m";
		}
		
		//restart game
		if(gamePanel.GetBool("Show") && Input.GetKeyDown("escape"))
			StartCoroutine(Restart());
		
		//quit game
		if(!gamePanel.GetBool("Show") && Input.GetKeyDown("escape"))
			Application.Quit();
	}
	
	//start game and start spawning
	public void StartGame(){
		levelSpawner.StartSpawning();
		
		startPanel.SetTrigger("Hide");
		gamePanel.SetBool("Show", true);
		
		
		Invoke("TipSound", 1.6f);
		
		buttonAudio.Play();
	}
	
	//play tip sound
	void TipSound(){
		tipSound.Play();
	}
	
	//set pause state
	public void Pause(bool paused){
		this.paused = paused;
	}
	
	public void PetDied(){
		//if game is not running, return
		if(!gamePanel.GetBool("Show"))
			return;
		
		//hide 1 heart
		if(hearts.Count > 0){
			Animator heart = hearts[0];
			hearts.Remove(heart);
			
			heart.SetTrigger("Hide");
		}
		
		//decrease pet count
		petCount--;
		
		//play sound
		deathSound.Play();
		
		//end game if there's no pets left
		if(petCount == 0)
			EndGame();
	}
	
	void EndGame(){
		//show game over screen and apply score
		gamePanel.SetBool("Show", false);
		gameOverPanel.SetTrigger("Game over");
		
		SetScore();
	}
	
	void SetScore(){
		//compare ran distance to best distance and update best distance
		int currentMeters = (int)meters;
		
		//show distance
		distText.text = currentMeters + "m";
		
		int savedDistance = PlayerPrefs.GetInt("Distance");
		
		if(savedDistance < currentMeters){
			PlayerPrefs.SetInt("Distance", currentMeters);
		}
		else{
			currentMeters = savedDistance;
		}
		
		//show best distance
		bestText.text = currentMeters + "m";
	}
	
	//play button sound and restart scene
	public void Continue(){
		buttonAudio.Play();
		
		StartCoroutine(Restart());
	}
	
	//wait for fade to complete and reload same scene
	IEnumerator Restart(){
		transition.SetTrigger("Fade in");
		
		yield return new WaitForSeconds(1f/3f);
		
		SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
	}
	
	//set settings state
	public void OpenCloseSettings(){
		settings.SetBool("Show settings", !settings.GetBool("Show settings"));
		
		buttonAudio.Play();
	}
	
	//enable/disable screenshake
	public void ToggleScreenshake(bool shake){
		PlayerPrefs.SetInt("Screenshake", shake ? 1 : 0);
		
		buttonAudio.Play();
	}
	
	//enable/disable music
	public void ToggleMusic(bool on){
		if(backgroundLoop.isPlaying && !on){
			backgroundLoop.Stop();
		}
		else if(!backgroundLoop.isPlaying && on){
			backgroundLoop.Play();
		}
		
		PlayerPrefs.SetInt("Music", on ? 0 : 1);
	}
}
