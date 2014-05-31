using UnityEngine;
using System.Collections;

public class CircleBehaviour : MonoBehaviour {
	public Vector2 pos;
	public GUIText acc;
	public float speed;
	public GameObject circle;
	private float Timer;
	private float yOffset;
	// Use this for initialization
	void Start () {
		Timer = 0.1f;
		speed = 0.5f;
		acc.text = "";
		yOffset = Input.acceleration.y;
	}
	
	// Update is called once per frame
	void Update () {
	
		float moveHorizontal = Input.acceleration.x;
		float moveVertical = Input.acceleration.y - yOffset;
		pos = transform.position;

		acc.text = "x = " + moveHorizontal + " y = " + moveVertical;

		circle.transform.Translate (moveHorizontal*speed, moveVertical*speed, 0);
		
		//Vector3 movement = new Vector3(moveHorizontal, moveVertical, 0.0f);
		
	}


}
