using UnityEngine;
using System.Collections;

public class DesligaOP : MonoBehaviour 
{
	public MovmentMenu ca;
	public GameObject[] desliga;

	// Use this for initialization
	void Start () 
	{
		if(PlayerPrefs.GetInt("Retry") == 2)
		{
			ca.enabled = true;
			for(int i = 0; i < desliga.Length; i++)
			{
				desliga[i].SetActive(false);
				Time.timeScale = 0;
			}
		}
	}
	
	// Update is called once per frame
	void Update () 
	{
	
	}
}
