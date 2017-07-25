using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Circle : MonoBehaviour {
	
	[HideInInspector]
	public float size;//scale factor circle

	void Start(){
		//apply asset
		transform.GetComponent<SpriteRenderer>().sprite = Settings.bundleImg.LoadAsset<Sprite>("assets/circle.png");
		Reset();
	}

	void Update () {
		//move circle
		//transform.localPosition -= new Vector3(0, (Settings.speed / size) / (5.0f * Settings.rateSpawn), 0) * Time.deltaTime;
		transform.localPosition -= new Vector3(0, (Settings.speed - 4.0f * Settings.rateSpawn) / size, 0) * Time.deltaTime;
		//hide the circle and assign a new color
		if(transform.localPosition.y < Settings.hight){
			Reset();
		}
	}
	//click on circle, hide, add score and play audio
	void OnMouseDown()
	{
		Reset();
		View.AddScore(size);
		View.click.Play();
	}
	//set scale size circle
	public void setSize(float scale){
		transform.localScale = new Vector3(scale, scale, scale);
		size = scale;
	}
	//get new color and hide
	void Reset(){
		transform.GetComponent<SpriteRenderer>().color = Settings.GetColor();
		gameObject.SetActive(false);
	}		
}