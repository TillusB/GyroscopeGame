using UnityEngine;
using System.Collections;

[RequireComponent(typeof(AudioSource))]

public class CameraBehaviour : MonoBehaviour {
	public SpawnTime[] spawnTimes;

	//public float[] spawnTimes;
	public GameObject spawnLocation;
	public GUIText comboText;
	public GUIText pointsText;

	public GameObject spawn;
	private float Timer;
	public float spawnTimer = 0;

	private SpawnBehaviour spbhv;
	private int combo;
	private int points;

	private int numberOfSpawns;

	// Use this for initialization
	void Start () {
		Timer = 1.0f;


		/*GameObject kreisPrefab = GameObject.Find ("kreisPrefab");
		spbhv = kreisPrefab.GetComponent<SpawnBehaviour> ();
		combo = spbhv.combo;
		points = spbhv.points;
		comboText.text = "";
		pointsText.text = "";
		*/


		numberOfSpawns = spawnTimes.Length;
	}

	private int channel;
	private int numSamples;


	// Update is called once per frame
	void Update () {

		for(int i = 0; i < spawnTimes.Length; i++) {
			if(audio.time >= spawnTimes[i].start && numberOfSpawns == spawnTimes.Length - i){
				Instantiate (spawn, new Vector3 (spawnLocation.transform.position.x, spawnLocation.transform.position.y, 0), Quaternion.identity);
				SpawnBehaviour.time = spawnTimes[i].end - spawnTimes[i].start;
				numberOfSpawns --;
			}
		}

		Debug.Log (audio.time);
	
		Timer -= Time.deltaTime;
		
	/*	if (Timer <= 0) {
			Instantiate (spawn, new Vector3 (0, 1, 0), Quaternion.identity);
			Timer = spawnTimer;
		}*/

	/*	combo = spbhv.combo;
		points = spbhv.points;
		comboText.text = "" + combo;
		pointsText.text = "" + points;


		print (points);
		print (combo);
	*/
}
	


}
