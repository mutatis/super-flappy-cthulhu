using UnityEngine;
using System.Collections;

public class CthulhuDagonFase : MonoBehaviour {

	public GameObject[] inicio;
	
	void Start()
	{
		Instantiate(inicio[PlayerPrefs.GetInt("Cthulhu")], new Vector3(57.954f, 12.912f, 0), Quaternion.identity);
	}
}
