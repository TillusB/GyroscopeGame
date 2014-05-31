using UnityEngine;
using System.Collections;
[System.Serializable]
public class SpawnTime {
	public float start;
	public float end;

	public bool isSwipe;

	public GameObject[] paths;

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		
	}

	float getStart(){
		return start;
	}

	void setStart(float newStart){
		start = newStart;
	}

	float getEnd(){
		return end;
	}
	
	void setEnd(float newEnd){
		end = newEnd;
	}

}
