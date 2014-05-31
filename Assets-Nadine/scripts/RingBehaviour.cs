using UnityEngine;
using System.Collections;

public class RingBehaviour : MonoBehaviour {

	public GameObject ring;
	private float Timer;
	float time;
	Hashtable hash = new Hashtable();
	public Color color;
	Vector3[] path = new Vector3[] {};
	public GameObject leveleditor;

	public SpawnTime[] spawnTimes;
	private int numberOfSpawns;
	
	// Use this for initialization
	void Start () {
		numberOfSpawns = spawnTimes.Length;



	}
	
	// Update is called once per frame
	void Update () {
		for(int i = 0; i < spawnTimes.Length; i++){
			if(leveleditor.audio.time >= spawnTimes[i].start && numberOfSpawns == spawnTimes.Length - i){

				time = spawnTimes[i].end - spawnTimes[i].start;

				path = NewPath(spawnTimes[i].paths);

				numberOfSpawns --;

				iTween.PutOnPath(gameObject, path, 1);
				gameObject.SetActive (true);
				hash.Clear();
				hash.Add ("name", "moveOnRandom");
				hash.Add ("path", path);
				hash.Add ("time", time);
				hash.Add ("oncomplete", "Die");
				hash.Add ("easetype", iTween.EaseType.linear);
				gameObject.SetActive (true);
				Move ();

			}
		}
		
	}

	void Move(){
		
		iTween.MoveFrom(gameObject, hash);
		
	}
	
	
	void Die(){

	}
	
	void OnDrawGizmos(){
		if(path.Length > 0){
			iTween.DrawPath (path, Color.white);
		}
	}
	
	
	Vector3[] NewPath(GameObject[] paths){

		Vector3[] mPath = new Vector3[paths.Length + 1];

		mPath[0] = ring.transform.position;

		for (int i = 0; i < paths.Length; i++) {
			mPath[i+1] = paths[i].transform.position;		
		}

		return mPath;
	}

}
