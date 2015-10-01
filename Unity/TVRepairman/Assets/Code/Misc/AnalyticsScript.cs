using UnityEngine;
using System.Collections;
using UnityEngine.Analytics;
using System.Collections.Generic;

public class AnalyticsScript : MonoBehaviour {



    void OnApplicationQuit()
    {
        Analytics.CustomEvent("QuitGame", new Dictionary<string, object>
        {
            { "TimePlayed", Mathf.RoundToInt(Time.time/60) }
        });
    }


	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

        if (Input.GetKeyDown(KeyCode.Escape))
            Application.Quit();
	
	}
}
