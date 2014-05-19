using UnityEngine;
using System.Collections;
[System.Serializable]
public class SpawnTime {
	public float start;
	public float end;
	public GameObject[] pathLength;
	public static Vector3[] path;
	// Use this for initialization
	void Start () {
		int i = 0;
			foreach (GameObject node in pathLength){
				path[i] = node.transform.position;
				i++;
			}

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
