using UnityEngine;
using System.Collections;
using UnityEngine.Cloud.Analytics;

public class UnityAnalyticsIntegration : MonoBehaviour {
	
	// Use this for initialization
	void Start () {
		
		const string projectId = "49087ee0-b215-4193-8457-dde2d4ce806f";
		UnityAnalytics.StartSDK (projectId);
		
	}
	
}