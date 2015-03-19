using UnityEngine;
using System.Collections;

public class Inicio : MonoBehaviour 
{
	public GameObject[] inicio;
	public ManagerCamera camera;

	public void Comeca()
	{
		for(int i = 0; i < inicio.Length; i++)
		{
			inicio[i].SetActive(true);
		}
		camera.enabled = true;
		gameObject.SetActive (false);
	}
}
