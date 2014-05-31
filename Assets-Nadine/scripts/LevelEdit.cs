using UnityEngine;
using System.Collections;

[RequireComponent(typeof(AudioSource))]

public class LevelEdit : MonoBehaviour {
	public SpawnTime[] spawnTimes;
	
	//public float[] spawnTimes;
	public GameObject spawnLocation;
	public GameObject spawn;
	private int numberOfSpawns;
	private int numberOfSpawns2;

	public GameObject pfadPrefab;

	public GUIText audioTime;


	// Use this for initialization
	void Start () {
		numberOfSpawns = spawnTimes.Length;
		numberOfSpawns2 = spawnTimes.Length;

		audioTime.text = "";

	}
	
	// Update is called once per frame
	void Update () {

		audioTime.text = "audioTime: " + audio.time;

		for(int i = 0; i < spawnTimes.Length; i++) {

			if(audio.time >= spawnTimes[i].start - 1 && numberOfSpawns2 == spawnTimes.Length - i){
				Instantiate (pfadPrefab, new Vector3 (spawnLocation.transform.position.x, spawnLocation.transform.position.y, 0), Quaternion.identity);
				PfadBehaviour.time = spawnTimes[i].end - spawnTimes[i].start;
				PfadBehaviour.pathNodes = spawnTimes[i].paths;
				numberOfSpawns2 --;
			} 

			if(audio.time >= spawnTimes[i].start && numberOfSpawns == spawnTimes.Length - i){
				Instantiate (spawn, new Vector3 (spawnLocation.transform.position.x, spawnLocation.transform.position.y, 0), Quaternion.identity);
				SpawnBehaviour.time = spawnTimes[i].end - spawnTimes[i].start;
				SpawnBehaviour.pathNodes = spawnTimes[i].paths;
				SpawnBehaviour.isSwipe = spawnTimes[i].isSwipe;
				numberOfSpawns --;
			}
		}
	}
}
