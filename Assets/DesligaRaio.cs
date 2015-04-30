using UnityEngine;
using System.Collections;

public class DesligaRaio : MonoBehaviour {

	// Use this for initialization
	void Start () {
		StartCoroutine("GO");
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	IEnumerator GO()
	{
		yield return new WaitForSeconds(2);
		Destroy(gameObject);
	}
}
