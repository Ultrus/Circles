using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {
	//circle 
	public GameObject circlePrefab;
	//list circles
	public List<GameObject> Circles;

	void Start () {
		InitCircles();
		InvokeRepeating("Spawn", 0, Settings.rateSpawn);
	}
	//create circles
	void InitCircles(){
		for(int i = 0; i < Settings.maxSpawnCircle; i++){
			GameObject tempCircle = Instantiate(circlePrefab) as GameObject;
			tempCircle.GetComponent<Circle>().setSize(Random.Range(Settings.minSizeCircle, Settings.maxSizeCircle));
			Circles.Add(tempCircle);
			tempCircle.transform.SetParent(gameObject.transform);
		}
	}
	//spawn circles
	private void Spawn(){
		float randSpawnRange = Random.Range(Settings.minSpawnRange, Settings.maxSpawnRange);
		GameObject tempCircle = null;

		for(int i = 0; i < Settings.maxSpawnCircle; i++){
			if(Circles[i].activeSelf == false){
				tempCircle = Circles[i];
				break;
			}
		}
		if(tempCircle != null){
			tempCircle.transform.localPosition = new Vector3(randSpawnRange, 0, tempCircle.transform.localPosition.z);
			tempCircle.SetActive(true);
		}
	}
	//update
	void Update()
	{
		//new repeatRate
		if (View.nextLevel){
			CancelInvoke("Spawn");
			Settings.rateSpawn -= 0.05f;
			InvokeRepeating("Spawn", 0, Settings.rateSpawn);
			View.nextLevel = false;
		}
	}
}
