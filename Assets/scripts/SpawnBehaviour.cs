	using UnityEngine;
	using System.Collections;

	public class SpawnBehaviour : MonoBehaviour {

	private bool inZone = false;
	public int points;
	public int combo;
	public static float time;
	public static GameObject[] pathNodes;
	Vector3 growSize;

	public GameObject[] zoneRechts;
	public static bool isSwipe;

	Hashtable hash = new Hashtable();
	public Color color;
	Vector3[] path = new Vector3[]{};

	public Material material;
	private TrailRenderer trail;

	// Use this for initialization
	void Start () {

		growSize = new Vector3(gameObject.transform.localScale.x * 1.5f, gameObject.transform.localScale.y * 1.5f, gameObject.transform.localScale.z * 1.5f);

		zoneRechts = GameObject.FindGameObjectsWithTag("Zone");

		path = NewPath();
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
		path.Initialize ();


		combo = HighscoreScript.combo;

		points = 0;


	}

	// Update is called once per frame
	void Update () {

		if (transform.position.x > 5.5 || transform.position.x < -5.5) { //TODO Nich so kaka fixen
			inZone = true;
		} else
			inZone = false;

		
		if (Input.touches.Length > 0 && Input.GetTouch (0).phase == TouchPhase.Began) {
			Touch touch = Input.GetTouch (0);

			Vector3 worldTouch = Camera.main.ScreenToWorldPoint(new Vector3(touch.position.x, touch.position.y, 0));


			if( !isSwipe && inZone && inSprite (worldTouch.x, worldTouch.y)){
				//spawn.transform.localScale = new Vector3(2,2,2);
				gameObject.transform.localScale = growSize;
			
				sleep(.5f);

				Destroy(gameObject);
				addPoints();
			}

			if(isSwipe && Input.GetTouch(0).phase == TouchPhase.Moved){
				gameObject.transform.localScale = growSize;
				addPoints();
			}
		}

	/*	if (transform.position.x > 9 || transform.position.x < -9 || transform.position.y > 6 || transform.position.y < -4) {
			Destroy (spawn);
			combo = 0;
				}*/
	}
	IEnumerator sleep(float time){
		yield return new WaitForSeconds(1);
	}

	void OnTriggerEnter2D(Collider2D coll){
		inZone = true;

		Debug.Log ("triggered");
			//print ("bla");
	}

		bool inSprite(float posX, float posY){
			
			float xPos = transform.position.x;
			float yPos = transform.position.y;
			float scaleX = transform.localScale.x;
			float scaleY = transform.localScale.y;
			float distX = scaleX / 2;
			float distY = scaleY / 2;
			
			float offset = scaleX / 4;
			
			float leftEdge = xPos - distX - offset;
			float rightEdge = xPos + distX + offset;
			float topEdge = yPos + distY + offset;
			float bottomEdge = yPos - distY - offset;
			
			bool isInside = posX >= leftEdge && posX <= rightEdge && posY >= bottomEdge && posY <= topEdge;
			
			return isInside;
		} 

	void Move(){
		
		iTween.MoveFrom(gameObject, hash);
		
	}
	
	
	void Die(){
		print ("dying!");
		inZone = true;
		sleep (5);
		Destroy (gameObject);
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

		datPath [0] = gameObject.transform.position;

		for(int i = 1; i < pathNodes.Length; i++){
			datPath[i] = pathNodes[i].transform.position;
		}

		//Vector3 point1 = new Vector3 (x,y);
		//Vector3 point2 = new Vector3(x + 4*dir, y + Random.Range(-3, 5));
		//Vector3 point3 = new Vector3 (x + 8*dir, y + Random.Range(-3, 5));
		//Vector3[] datPath = new [] {point1, point2, point3};
		return datPath;
	}


	void addPoints(){
			combo += 1;
			if (combo >= 5) {
				points += 50;		
			} else if (combo >= 10) {
				points += 100;			
			} else {
				points += 20;
			}
		HighscoreScript.points += points;
		HighscoreScript.combo += 1;

		}
	}
