using UnityEngine;
using System.Collections;

public class RingBehaviour : MonoBehaviour {

	public GameObject ring;
	private float Timer;
	public float time;
	Hashtable hash = new Hashtable();
	public Color color;
	Vector3[] path = new Vector3[]{};
	GameObject[] aPositions;
	public GameObject pos1;
	public GameObject pos1a;
	public GameObject pos2;
	public GameObject pos2a;
	public GameObject pos3;
	public GameObject pos3a;
	public GameObject pos4;
	public GameObject pos4a;
	public GameObject pos5;
	public GameObject pos5a;
	public GameObject pos6;
	public GameObject pos6a;
	GameObject[] positions;
	// Use this for initialization
	void Start () {
		aPositions = new GameObject[] {pos1a, pos2a, pos3a, pos4a, pos5a, pos6a};
		positions = new GameObject[] {pos1, pos2, pos3, pos4, pos5, pos6};
		path = NewPath ();
		iTween.PutOnPath(gameObject, path, 1);
		gameObject.SetActive (true);
		hash.Clear();
		hash.Add ("name", "moveOnRandom");
		hash.Add ("path", path);
		hash.Add ("time", time);
		hash.Add ("oncomplete", "Die");
		hash.Add ("easetype", iTween.EaseType.easeInOutSine);
		gameObject.SetActive (true);
		Move ();
	}
	
	// Update is called once per frame
	void Update () {

	}

	void Move(){
		
		iTween.MoveFrom(gameObject, hash);
		
	}
	
	
	void Die(){
		//gameObject.SetActive (false);
		NewPath ();
		Start ();
	}
	
	void OnDrawGizmos(){
		if(path.Length > 0){
			iTween.DrawPath (path, Color.white);
		}
	}
	
	
	Vector3[] NewPath(){

		Vector3 point1;
		Vector3 point2;
		Vector3 point3;
		point1 = new Vector3(0,0,0);
		point2 = new Vector3(0,0,0);
		point3 = new Vector3(0,0,0);
		foreach(GameObject g in positions){
			if(gameObject.transform.position != g.transform.position){
				int i = Random.Range(0,5);
				point1 = gameObject.transform.position;
				point2 = aPositions[i].transform.position;
				point3 = positions[i].transform.position;
			}
		}
			

		Vector3[] datPath = new [] {point1, point2, point3};
		return datPath;
	}

}
