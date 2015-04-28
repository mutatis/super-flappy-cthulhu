using UnityEngine;
using System.Collections;

public class Inicio : MonoBehaviour 
{
	public GameObject tap;
	public GameObject[] inicio;
	public ManagerCamera camera;
	int num;

	public void Comeca()
	{
		num = Random.Range(0, inicio.Length);
		Instantiate(inicio[num], new Vector3(57.954f, 12.912f, 0), Quaternion.identity);
		tap.SetActive (true);
		camera.enabled = true;
		gameObject.SetActive (false);
		PlayerPrefs.SetInt("Cthulhu", num);
		PlayerPrefs.SetInt("Musica", 1);
	}
}