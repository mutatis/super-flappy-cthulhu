using UnityEngine;
using System.Collections;

public class DesligaOP : MonoBehaviour 
{
	public MovmentMenu ca;
	public GameObject[] desliga;
	int x;
	string y;

	// Use this for initialization
	void Start () 
	{
		desliga[3].SetActive(false);
		if(PlayerPrefs.GetInt("Retry") == 2)
		{
			ca.enabled = true;
			for(int i = 0; i < desliga.Length; i++)
			{
				desliga[i].SetActive(false);
				Time.timeScale = 0;
			}
		}
		for(int i = 0; i < desliga.Length; i++)
		{
			desliga[i].SetActive(false);
			Time.timeScale = 0;
		}
		StartCoroutine("GO");
	}

	IEnumerator GO()
	{
		float start = Time.realtimeSinceStartup;
		while (Time.realtimeSinceStartup < start + 10)
		{
			yield return null;
		}
		Application.LoadLevel("LoadVideo");
	}

	// Update is called once per frame
	void Update () 
	{
	
	}
}
