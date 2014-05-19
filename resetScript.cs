using UnityEngine;
using System.Collections;

public class resetScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
		if (Input.touches.Length > 0 && Input.GetTouch (0).phase == TouchPhase.Moved) {
			Touch touch = Input.GetTouch (0);
			Vector3 worldTouch = Camera.main.ScreenToWorldPoint (new Vector3 (touch.position.x, touch.position.y, 0));

			if (inside (worldTouch.x, worldTouch.y)) {
				Application.LoadLevel ("proto");
				}
			}
		}

		bool inside (float posX, float posY){
			
			float xPos = transform.position.x;
			float yPos = transform.position.y;
			float scaleX = transform.localScale.x;
			float scaleY = transform.localScale.y;
			float distX = scaleX / 2;
			float distY = scaleY / 2;
			
			
			
			float leftEdge = xPos - distX;
			float rightEdge = xPos + distX;
			float topEdge = yPos + distY;
			float bottomEdge = yPos - distY;
			
			bool isInside = posX >= leftEdge && posX <= rightEdge && posY >= bottomEdge && posY <= topEdge;
			
			return isInside;
		} 
}
