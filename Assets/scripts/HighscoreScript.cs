using UnityEngine;
using System.Collections;

public class HighscoreScript : MonoBehaviour {


	public static int points;
	public static int combo;


	public GUIText pointsText;
	public GUIText comboText;

	// Use this for initialization
	void Start () {
	
		points = 0;
		combo = 0;

		pointsText.text = "points: " + points;
		comboText.text = "combo: " + combo;
	}
	
	// Update is called once per frame
	void Update () {
	
		pointsText.text = "points: " + points;
		comboText.text = "combo: " + combo;

	}
}
