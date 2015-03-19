using UnityEngine;
using System.Collections;

public class DesligaAnim : MonoBehaviour 
{
	public Animator anim;
	// Use this for initialization
	void Start () 
	{
	
	}
	
	// Update is called once per frame
	void Update () 
	{
	
	}

	public void Desliga()
	{
		anim.enabled = false;
	}
}
