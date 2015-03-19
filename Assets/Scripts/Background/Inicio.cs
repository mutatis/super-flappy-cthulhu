using UnityEngine;
using System.Collections;

public class Inicio : MonoBehaviour 
{
	public GameObject tap;
	public GameObject[] inicio;
	public ManagerCamera camera;

	public void Comeca()
	{
		Instantiate(inicio[Random.Range(0, inicio.Length)], new Vector3(57.954f, 12.912f, 0), Quaternion.identity);
		tap.SetActive (true);
		camera.enabled = true;
		gameObject.SetActive (false);
	}
}
