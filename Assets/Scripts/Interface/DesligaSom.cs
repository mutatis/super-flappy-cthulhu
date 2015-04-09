using UnityEngine;
using System.Collections;

public class DesligaSom : MonoBehaviour {

	public void OnOff()
	{
		if(PlayerPrefs.GetInt("ONOFF") == 0)
		{
			PlayerPrefs.SetInt("ONOFF", 1);
		}
		else
		{
			PlayerPrefs.SetInt("ONOFF", 0);
		}
	}
}
