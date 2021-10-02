using UnityEngine;
using System.Collections;

public class MusicManager : MonoBehaviour {
	
	public AudioClip[] levelMusicChangeArray;
	private AudioSource audioSource;
	
	void Awake(){
		DontDestroyOnLoad (gameObject);
		Debug.Log ("Dont Destroy on Load" + name);
	}

	// Use this for initialization
	void Start () {
		audioSource =  GetComponent<AudioSource>();
	}
	
	void OnLevelWasLoaded(int level){
		AudioClip thisLevelMusic = levelMusicChangeArray[level];
		Debug.Log ("Playing Clip" + thisLevelMusic);
		
		if (thisLevelMusic) {// if theres some music attatched
			audioSource.clip = thisLevelMusic;
			audioSource.loop = true;
			audioSource.Play ();
		}
	}
	public void SetVolume (float volume) {
		audioSource.volume = volume;
		
	}
}
