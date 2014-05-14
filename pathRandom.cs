using UnityEngine;
using System.Collections;

public class pathRandom : MonoBehaviour {

	Hashtable hash = new Hashtable();
	public Color color;
	Vector3[] path = new Vector3[]{};
	// Use this for initialization
	void Start () {
		path = NewPath ();
		iTween.PutOnPath(gameObject, path, 1);
		gameObject.SetActive (true);
		hash.Clear();
		hash.Add ("name", "moveOnRandom");
		hash.Add ("path", path);
		hash.Add ("time", 3);
		hash.Add ("oncomplete", "Die");
		hash.Add ("easetype", iTween.EaseType.easeInOutSine);

		gameObject.SetActive (true);
		Move ();
	}
	
	// Update is called once per frame
	void FixedUpdate () {

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
		Vector3 point1 = new Vector3 (-10,0);
		Vector3 point2 = new Vector3(-5, Random.Range(-5, 5));
		Vector3 point3 = new Vector3 (0, Random.Range(-5, 5));
		Vector3[] datPath = new [] {point1, point2, point3};
		return datPath;
	}


	
}
