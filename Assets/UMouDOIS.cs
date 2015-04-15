using UnityEngine;
using System.Collections;

public class UMouDOIS : MonoBehaviour 
{
	public GameObject[] obj;

	// Use this for initialization
	void Start () 
	{
		if(PlayerPrefs.GetInt("Retry") != 2)
			obj[Random.Range(0, obj.Length)].SetActive(true);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
