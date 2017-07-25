using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class View : MonoBehaviour {

	//UItext score and timer
	private static int score;
	[HideInInspector]
	public float time;

	public Text scoreText;

	public Text timerText;
	//counters next level and current level 
	[HideInInspector]
	public int upLevel, currentLevel;
	//level up
	public static bool nextLevel;

	public static AudioSource click;

	void Start(){
		click = transform.gameObject.GetComponent<AudioSource>();
		click.clip = Settings.bundleSnd.LoadAsset<UnityEngine.AudioClip>("assets/button.mp3");
	}
	//new score
	public static void AddScore (float value) {
		score += (int)(10.0f / value);
	}
	//update
	void Update () {
		//timer
		time += Time.deltaTime;
		string minutes = Mathf.Floor(time / 60).ToString("00");
		string seconds = Mathf.Floor(time % 60).ToString("00");
		scoreText.text = "Score : " + score;
		timerText.text = minutes + ":" + seconds;
		//level counter
		upLevel = (int)(Mathf.Floor(time % 120));
		if (upLevel > currentLevel && Settings.rateSpawn > 0.1f){
			currentLevel = upLevel;
			nextLevel = true;
		}
	}
}
