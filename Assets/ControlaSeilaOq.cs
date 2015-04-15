using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ControlaSeilaOq : MonoBehaviour {

	public float num;
	public int num2;
	public GameObject[] logo;
	public float num3;
	public float num4;
	public Image[] image;
	public Transform pos;
	public GameObject[] desliga;
	bool vai;
	public MovmentMenu ca;
	//public Transform camera;
	
	// Use this for initialization
	void Start ()
	{

	}
	
	// Update is called once per frame
	void Update () 
	{
		/*if(camera.position.y  > num2)
		{
			camera.Translate(0, -10, 0);
		}
		else
		{
			camera.position = new Vector3(transform.position.x, num2, 0);
		}*/
		if(vai == false)
		{
			for(int i = 0; i < logo.Length; i++)
			{
				logo[i].SetActive(true);
			}
			for(int i = 0; i < image.Length; i++)
			{
				image[i].enabled = true;
			}
			if(num2 == 0)
			{
				transform.position = new Vector2(transform.position.x, pos.position.y);
			}
			else
			{
				transform.position = new Vector3(transform.position.x, num, num3);
			}
		}
	}
}
