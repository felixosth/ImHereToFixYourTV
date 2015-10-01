using UnityEngine;
using System.Collections;

public class MissionMng : MonoBehaviour {


	public string currentMission = "none";

    public bool missionIsActive = false;

	// Use this for initialization
	void Start () {

        if (FindObjectsOfType(GetType()).Length > 1)
            Destroy(gameObject);
        else
		    DontDestroyOnLoad(gameObject);
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
