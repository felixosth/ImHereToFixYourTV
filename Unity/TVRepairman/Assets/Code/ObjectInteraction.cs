using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ObjectInteraction : MonoBehaviour {


    bool isOnComputer = false;
    public bool canMove = true;

    public Camera computerCamera;
    Camera plyCam;
    public GameObject plyCamObj;

	// Use this for initialization
	void Start () {

        plyCam = plyCamObj.GetComponent<Camera>();
	
	}

    GameObject lastObj;

	// Update is called once per frame
	void Update () {

        RaycastHit hit;
        Ray objRay = new Ray(plyCam.transform.position, plyCam.transform.forward);
        Debug.DrawRay(plyCam.transform.position, plyCam.transform.forward, Color.red);
        if (Physics.Raycast(objRay, out hit, 2.5f))
        {
            if (hit.collider.tag == "Interactable")
            {
                if (lastObj != null)
                    lastObj.GetComponent<InteractableObject>().isLookingAt = false;

                lastObj = hit.collider.gameObject;
                var script = hit.collider.GetComponent<InteractableObject>();


                if(!isOnComputer)
                    script.isLookingAt = true;

                if (Input.GetMouseButtonDown(0))
                {
                    switch (script.DisplayText)
                    {
                        case "Computer":
                            if (canMove)
                            {
                                computerCamera.enabled = true;
                                isOnComputer = true;
                                plyCam.enabled = false;
                                canMove = false;
                                script.isLookingAt = false;
                            }
                            break;
                    }
                }

            }
        }
        else
        {
            if (lastObj != null)
            {
                lastObj.GetComponent<InteractableObject>().isLookingAt = false;
                lastObj = null;
            }
        }

        if (!isOnComputer)
        {
            var objs = GameObject.FindGameObjectsWithTag("ComputerButton");
            foreach (GameObject gb in objs)
            {
                gb.GetComponent<Button>().interactable = false;
            }
        }
        else
        {
            var objs = GameObject.FindGameObjectsWithTag("ComputerButton");
            foreach (GameObject gb in objs)
            {
                gb.GetComponent<Button>().interactable = true;
            }
        }


        if (Input.GetMouseButtonDown(1))
        {
            if (isOnComputer && !canMove)
            {
                plyCam.enabled = true;
                isOnComputer = false;

                computerCamera.enabled = false;
                canMove = true;
            }
        }
    }
}
