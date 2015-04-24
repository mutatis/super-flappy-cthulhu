using UnityEngine;
using System.Collections;
using UnityEngine.SocialPlatforms;
using UnityEngine.UI;

public class TextHoghScore : MonoBehaviour {
	Text text;
	// Use this for initialization
	void Start () {
		text = GetComponent<Text>();
		text.text = "" + (PlayerPrefs.GetInt("flappyS"));
	}
	
	// Update is called once per frame
	void Update () {

	}
}