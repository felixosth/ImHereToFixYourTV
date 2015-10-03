using UnityEngine;
using System.Collections;

public class TravelCanvasManagerScript : MonoBehaviour {

    public GameObject canvas;
    public ObjectInteraction objInt;


    public void EnableTravelCanvas()
    {
        objInt.canMove = false;
        canvas.SetActive(true);
        canvas.GetComponent<FastTravelScript>().Refresh();

        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
    }

    public void DisableTravelCanvas()
    {
        objInt.canMove = true;

        canvas.SetActive(false);


        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
