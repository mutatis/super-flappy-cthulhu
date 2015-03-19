using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class PushNotificationsAndroid : MonoBehaviour {

	// Use this for initialization
	void Start () {
		InitPushwoosh();
		registerForPushNotifications();
		
		Debug.Log(this.gameObject.name);
		Debug.Log(getPushToken());
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	private static AndroidJavaObject pushwoosh = null;
	
	void InitPushwoosh() {
		if(pushwoosh != null)
			return;
		
		using(var pluginClass = new AndroidJavaClass("com.arellomobile.android.push.PushwooshProxy"))
		pushwoosh = pluginClass.CallStatic<AndroidJavaObject>("instance");
		
		pushwoosh.Call("setListenerName", this.gameObject.name);
	}
 
	public void setIntTag(string tagName, int tagValue)
	{
		pushwoosh.Call("setIntTag", tagName, tagValue);
	}

	public void registerForPushNotifications()
	{
		pushwoosh.Call("registerForPushNotifications");
	}

	public void unregisterForPushNotifications()
	{
		pushwoosh.Call("unregisterFromPushNotifications");
	}

	public void setStringTag(string tagName, string tagValue)
	{
		pushwoosh.Call("setStringTag", tagName, tagValue);
	}

	public void setListTag(string tagName, List<object> tagValues)
	{
		AndroidJavaObject tags = new AndroidJavaObject ("com.arellomobile.android.push.TagValues");

		foreach( var tagValue in tagValues )
		{
			tags.Call ("addValue", tagValue);
		}

		pushwoosh.Call ("setListTag", tagName, tags);
	}
	
	public void sendLocation(double lat, double lon)
	{
		pushwoosh.Call("sendLocation", lat, lon);
	}

	public void startTrackingGeoPushes()
	{
		pushwoosh.Call("startTrackingGeoPushes");
	}

	public void stopTrackingGeoPushes()
	{
		pushwoosh.Call("stopTrackingGeoPushes");
	}

	public void clearLocalNotifications()
	{
		pushwoosh.Call("clearLocalNotifications");
	}

	public void scheduleLocalNotification(string message, int seconds)
	{
		pushwoosh.Call("scheduleLocalNotification", message, seconds);
	}

	public void scheduleLocalNotification(string message, int seconds, string userdata)
	{
		pushwoosh.Call("scheduleLocalNotification", message, seconds, userdata);
	}
	
	public void setMultiNotificationMode()
	{
		pushwoosh.Call("setMultiNotificationMode");
	}

	public void setSimpleNotificationMode()
	{
		pushwoosh.Call("setSimpleNotificationMode");
	}

	/* 
	 * Sound notification types:
	 * 0 - default mode
	 * 1 - no sound
	 * 2 - always
	 */
	public void setSoundNotificationType(int soundNotificationType)
	{
		pushwoosh.Call("setSoundNotificationType", soundNotificationType);
	}

	/* 
	 * Vibrate notification types:
	 * 0 - default mode
	 * 1 - no vibrate
	 * 2 - always
	 */
	public void setVibrateNotificationType(int vibrateNotificationType)
	{
		pushwoosh.Call("setVibrateNotificationType", vibrateNotificationType);
	}

	public void setLightScreenOnNotification(bool lightsOn)
	{
		pushwoosh.Call("setLightScreenOnNotification", lightsOn);
	}

	public void setEnableLED(bool ledOn)
	{
		pushwoosh.Call("setEnableLED", ledOn);
	}
	
	public string getPushToken()
	{
		return pushwoosh.Call<string>("getPushToken");
	}

	public string getPushwooshHWID()
	{
		return pushwoosh.Call<string>("getPushwooshHWID");
	}

	void onRegisteredForPushNotifications(string token)
	{
		GameObject text = GameObject.Find("Status Text");
		TextMesh textMesh = text.GetComponent<TextMesh>();
		textMesh.text = token;

		//do handling here
		Debug.Log(token);
	}

	void onFailedToRegisteredForPushNotifications(string error)
	{
		GameObject text = GameObject.Find("Status Text");
		TextMesh textMesh = text.GetComponent<TextMesh>();
		textMesh.text = error;

		//do handling here
		Debug.Log(error);
	}

	void onPushNotificationsReceived(string payload)
	{
		GameObject text = GameObject.Find("Status Text");
		TextMesh textMesh = text.GetComponent<TextMesh>();
		textMesh.text = payload;

		//do handling here
		Debug.Log(payload);
	}
	void OnApplicationPause(bool paused)
	{
		//make sure everything runs smoothly even if pushwoosh is not initialized yet
		if (pushwoosh == null)
			InitPushwoosh();

		if(paused)
		{
			pushwoosh.Call("onPause");
		}
		else
		{
			pushwoosh.Call("onResume");
		}
	}
}
