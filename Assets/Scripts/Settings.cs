using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Settings : MonoBehaviour {

	//for initialization game settings

	public static float speed = 8.0f;//base speed circles

	public static float hight = -14.0f;//minimum height of hiding circle

	public static float maxSpawnRange;//maximum screen width in world coordinates

	public static float minSpawnRange;///minimum screen width in world coordinates

	public static float rateSpawn = 1.5f;

	public static float maxSizeCircle = 1.1f;

	public static float minSizeCircle = 0.35f;

	public static int maxSpawnCircle = 20;

	private static Color[] colors = new Color[6];

	private float width, height;

	public static AssetBundle bundleImg;

	public static AssetBundle bundleSnd;

	void Awake()
	{
		colors[0] = Color.cyan;
		colors[1] = Color.red;
		colors[2] = Color.green;
		colors[3] = new Color(255, 165, 0);
		colors[4] = Color.yellow;
		colors[5] = Color.magenta;
		maxSpawnRange = GetWidthToWorld() / 2.0f;
		minSpawnRange = -GetWidthToWorld() / 2.0f;
		LoadAssetsFromBundle();
	}
	//get rand colors for circle
	public static Color GetColor(){
		return colors[Random.Range(0, colors.Length)];
	}
	//get screen width in real world coordinates
	float GetWidthToWorld(){
	  height = Camera.main.orthographicSize * 2.0f;
	  width = height * Camera.main.aspect;
	  return width;
	}
	//load image and sound from assets
	void LoadAssetsFromBundle()
	{
		bundleImg = AssetBundle.LoadFromFile("Assets/AssetBundle/Game/circle");
		if (bundleImg == null)
		{
			Debug.Log("Failed to load Asset bundleImg!");
			return;
		}

		bundleSnd = AssetBundle.LoadFromFile("Assets/AssetBundle/Game/click");
		if (bundleSnd == null)
		{
			Debug.Log("Failed to load Asset bundleSnd!");
			return;
		}
	}
}
