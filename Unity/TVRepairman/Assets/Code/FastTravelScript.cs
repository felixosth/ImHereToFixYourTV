using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class FastTravelScript : MonoBehaviour {


    public Button apartmentTravel;
    public Button missionTravel;
    public MissionMng missionMng;


    public GameObject loadingCanvas;

    public void Refresh()
    {
        if(Application.loadedLevelName == "apartment")
        {
            apartmentTravel.interactable = false;

            missionTravel.interactable = missionMng.missionIsActive;

        }
        else
        {
            apartmentTravel.interactable = true;
            missionTravel.interactable = false;
        }
    }

    public void Travel(string location)
    {
        gameObject.SetActive(false);
        loadingCanvas.SetActive(true);

        if(location == "mission")
        {
            Application.LoadLevel(missionMng.currentMission);
        }
        else if(location == "apartment")
        {
            Application.LoadLevel(location);
        }
    }

	// Use this for initialization
	void Start () {

        missionMng = GameObject.Find("MissionManager").GetComponent<MissionMng>();
        Refresh();
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
