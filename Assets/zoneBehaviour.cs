using UnityEngine;
using System.Collections;

public class zoneBehaviour : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	void OnTriggerEnter(Collider coll){
				print ("bla");
				if (coll.tag == "Bubble" || coll.tag == "Zone") {
						print ("YOOO");
				}
		}

	// Update is called once per frame
	void Update () {
	
	}
}
