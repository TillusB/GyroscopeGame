	using UnityEngine;
	using System.Collections;

	public class SpawnBehaviour : MonoBehaviour {


	public GameObject spawn;

	private float X;
	private float Y;
	private bool inZone = false;
	public int points;
	public int combo;
	public static float time;
	public static GameObject[] pathNodes;
	Hashtable hash = new Hashtable();
	public Color color;
	Vector3[] path = new Vector3[]{};

	public Material material;

	private LineRenderer line;

	// Use this for initialization
	void Start () {
		path = NewPath();
		iTween.PutOnPath(spawn, path, 1);
		spawn.SetActive (true);
		hash.Clear();
		hash.Add ("name", "moveOnRandom");
		hash.Add ("path", path);
		hash.Add ("time", time);
		hash.Add ("oncomplete", "Die");
		hash.Add ("easetype", iTween.EaseType.easeInOutSine);
		
		spawn.SetActive (true);
		Move ();
		path.Initialize ();


		line = spawn.AddComponent("LineRenderer") as LineRenderer;
		line.SetWidth (0.1f, 0.1f);
		line.material = material;
		line.SetColors (Color.white, Color.white);
		line.SetVertexCount (path.Length);
		line.renderer.enabled = true;

		for (int i = 0; i < path.Length; i++) {
			line.SetPosition(i, path[i]);		
		}


		X = Random.Range (-0.1f, 0.1f);
		Y = Random.Range (-0.0f, 0.0f);
		points = 0;


	}

	// Update is called once per frame
	void Update () {

		//spawn.transform.Translate (X, Y, 0);

		if (Input.touches.Length > 0 && Input.GetTouch (0).phase == TouchPhase.Moved) {
			Touch touch = Input.GetTouch (0);

			Vector3 worldTouch = Camera.main.ScreenToWorldPoint(new Vector3(touch.position.x, touch.position.y, 0));


			if(inZone && inSprite (worldTouch.x, worldTouch.y)){
				Destroy(spawn);
				addPoints();
			}
			
		}

	/*	if (transform.position.x > 9 || transform.position.x < -9 || transform.position.y > 6 || transform.position.y < -4) {
			Destroy (spawn);
			combo = 0;
				}*/
	}

	void OnTriggerEnter2D(Collider2D coll){
			inZone = true;	
			print ("bla");
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
		
		iTween.MoveFrom(spawn, hash);
		
	}
	
	
	void Die(){
		gameObject.SetActive (false);
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

		datPath [0] = spawn.transform.position;

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
		}
	}
