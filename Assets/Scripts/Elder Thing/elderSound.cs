using UnityEngine;
using System.Collections;

public class elderSound : MonoBehaviour {
	
	public AudioClip bate;

	// Use this for initialization
	void Start () 
	{
	
	}
	
	// Update is called once per frame
	void Update () 
	{
	
	}

	public void Play()
	{
		AudioSource.PlayClipAtPoint(bate, new Vector3(transform.position.x, transform.position.y, transform.position.z));
	}
}
