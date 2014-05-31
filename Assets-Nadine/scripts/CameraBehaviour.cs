using UnityEngine;
using System.Collections;


public class CameraBehaviour : MonoBehaviour {
	public GUIText comboText;
	public GUIText pointsText;


	private float Timer;

	private int combo;
	private int points;



	// Use this for initialization
	void Start () {
		Timer = 1.0f;


		/*GameObject kreisPrefab = GameObject.Find ("kreisPrefab");
		spbhv = kreisPrefab.GetComponent<SpawnBehaviour> ();
		combo = spbhv.combo;
		points = spbhv.points;
		comboText.text = "";
		pointsText.text = "";
		*/



	}

	private int channel;
	private int numSamples;


	// Update is called once per frame
	void Update () {
		
		Timer -= Time.deltaTime;
		
	/*	if (Timer <= 0) {
			Instantiate (spawn, new Vector3 (0, 1, 0), Quaternion.identity);
			Timer = spawnTimer;
		}*/

	/*	combo = spbhv.combo;
		points = spbhv.points;
		comboText.text = "" + combo;
		pointsText.text = "" + points;


		print (points);
		print (combo);
	*/
}
	


}
