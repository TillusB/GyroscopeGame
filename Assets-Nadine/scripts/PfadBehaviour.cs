using UnityEngine;
using System.Collections;

public class PfadBehaviour : MonoBehaviour {
	
	
	public GameObject pfadPrefab;

	public static float time;
	public static GameObject[] pathNodes;

	Hashtable hash = new Hashtable();
	public Color color;

	Vector3[] path = new Vector3[]{};
	
	public Material material;
	
	private TrailRenderer trail;
	
	// Use this for initialization
	void Start () {
		path = NewPath();
		iTween.PutOnPath(pfadPrefab, path, 1);
		pfadPrefab.SetActive (true);
		hash.Clear();
		hash.Add ("name", "moveOnRandom");
		hash.Add ("path", path);
		hash.Add ("time", time);
		hash.Add ("oncomplete", "Die");
		hash.Add ("easetype", iTween.EaseType.linear);
		
		pfadPrefab.SetActive (true);
		Move ();
		path.Initialize ();
		
		
		trail = pfadPrefab.AddComponent("TrailRenderer") as TrailRenderer;
		trail.material = material;
		trail.startWidth = 0.1f;
		trail.endWidth = 0.2f;
		trail.time = 5;
		trail.renderer.enabled = true;
	}
	
	// Update is called once per frame
	void Update () {

		if (Input.touches.Length > 0 && Input.GetTouch (0).phase == TouchPhase.Moved) {
			Touch touch = Input.GetTouch (0);
			
			Vector3 worldTouch = Camera.main.ScreenToWorldPoint(new Vector3(touch.position.x, touch.position.y, 0));

			
		}
		
		/*	if (transform.position.x > 9 || transform.position.x < -9 || transform.position.y > 6 || transform.position.y < -4) {
			Destroy (spawn);
			combo = 0;
				}*/
	}

	void Move(){
		
		iTween.MoveFrom(pfadPrefab, hash);
		
	}

	void Die(){
		//gameObject.SetActive (false);
		//NewPath ();
		//Start ();
	}

	Vector3[] NewPath(){
		int dir = 0;
		float x = transform.position.x;
		float y = transform.position.y;
		if (Random.Range (0, 2) == 0) {
			dir = 1;
		} else {
			dir = -1;
		}
		
		Vector3[] datPath = new Vector3[pathNodes.Length];
		
		datPath [0] = pfadPrefab.transform.position;
		
		for(int i = 1; i < pathNodes.Length; i++){
			datPath[i] = pathNodes[i].transform.position;
		}

		return datPath;
	}

}
