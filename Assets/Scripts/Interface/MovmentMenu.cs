using UnityEngine;
using System.Collections;

public class MovmentMenu : MonoBehaviour {

	public float num;
	public float num2;
	public GameObject[] logo;
	//public Transform camera;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		Debug.Log(transform.position.y);
		/*if(camera.position.y  > num2)
		{
			camera.Translate(0, -10, 0);
		}
		else
		{
			camera.position = new Vector3(transform.position.x, num2, 0);
		}*/
		if(transform.position.y  > num)
		{
			transform.Translate(0, -10, 0);
		}
		else
		{
			transform.position = new Vector2(transform.position.x, num);
			for(int i = 0; i < logo.Length; i++)
			{
				logo[i].SetActive(true);
			}
		}
	}
}
