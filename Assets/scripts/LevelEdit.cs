using UnityEngine;
using System.Collections;

[RequireComponent(typeof(AudioSource))]

public class LevelEdit : MonoBehaviour {
	public SpawnTime[] spawnTimes;
	
	//public float[] spawnTimes;
	public GameObject spawnLocation;
	public GameObject spawn;
	private int numberOfSpawns;

	// Use this for initialization
	void Start () {
		numberOfSpawns = spawnTimes.Length;

	}
	
	// Update is called once per frame
	void Update () {
		for(int i = 0; i < spawnTimes.Length; i++) {
			if(audio.time >= spawnTimes[i].start && numberOfSpawns == spawnTimes.Length - i){
				Instantiate (spawn, new Vector3 (spawnLocation.transform.position.x, spawnLocation.transform.position.y, 0), Quaternion.identity);
				SpawnBehaviour.time = spawnTimes[i].end - spawnTimes[i].start;
				SpawnBehaviour.pathNodes = spawnTimes[i].paths;
				numberOfSpawns --;
			}
		}
	}
}
