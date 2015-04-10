using UnityEngine;
using System.Collections;

public class DayNight : MonoBehaviour 
{

	public GameObject[] background;
	public GameObject[] chao;
	public GameObject[] morte;
	public GameObject[] obj;
	int x;

	// Use this for initialization
	void Start () 
	{
		x = Random.Range (0, background.Length);
		background [x].SetActive (true);
		chao [x].SetActive (true);
		morte [x].SetActive (true);
		if(x % 2 == 0)
		{
			obj[0].SetActive(true);
		}
		else
		{
			obj[1].SetActive(true);
		}
	}
	
	// Update is called once per frame
	void Update () 
	{
	
	}
}
