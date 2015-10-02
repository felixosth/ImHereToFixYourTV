using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ObjectInteraction : MonoBehaviour {


    bool isOnComputer = false;
    public bool canMove = true;

    public float InteractionDistance = 3f;

    public Camera computerCamera;
    Camera plyCam;
    public GameObject plyCamObj;

    public Color hudImageColor;

    public bool isRepairingTV = false;

    public GameObject hudCanvas;


    public Camera lastTVCam;
    bool blockRayThisFrame = false;

    public GameObject currentTV;

    InventoryManagement invMng;

	// Use this for initialization
	void Start () {
        invMng = GetComponent<InventoryManagement>();

        plyCam = plyCamObj.GetComponent<Camera>();

        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    GameObject lastObj;

	// Update is called once per frame
	void Update () {

        blockRayThisFrame = false;

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


        if(Input.GetMouseButton(0) && canMove && Cursor.lockState != CursorLockMode.Locked)
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }

        if (Input.GetKeyDown(KeyCode.C) && Cursor.lockState == CursorLockMode.Locked)
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }

        if (Input.GetKeyDown(KeyCode.E))
        {
            if (isOnComputer && !canMove)
            {
                blockRayThisFrame = true;

                Cursor.lockState = CursorLockMode.Locked;
                Cursor.visible = false;
                plyCam.enabled = true;
                isOnComputer = false;

                computerCamera.enabled = false;
                canMove = true;
            }
            else if (isRepairingTV && !canMove)
            {
                blockRayThisFrame = true;

                isRepairingTV = false;
                plyCam.enabled = true;
                lastTVCam.enabled = false;
                lastTVCam.GetComponent<PhysicsRaycaster>().enabled = false;

                Cursor.lockState = CursorLockMode.Locked;
                Cursor.visible = false;
                canMove = true;
            }
        }


        if (lastObj != null)
        {
            lastObj.GetComponent<InteractableObject>().isLookingAt = false;
            hudCanvas.GetComponentInChildren<Image>().sprite = null;
            hudCanvas.GetComponentInChildren<Text>().text = "";
            var img = hudCanvas.GetComponentInChildren<Image>();

            img.color = new Color(1, 1, 1, 0);

        }
        RaycastHit hit;
        Ray objRay = new Ray(plyCam.transform.position, plyCam.transform.forward);
        Debug.DrawRay(plyCam.transform.position, plyCam.transform.forward, Color.red);
        if (Physics.Raycast(objRay, out hit, InteractionDistance) && !blockRayThisFrame)
        {
            if (hit.collider.tag == "Interactable")
            {


                lastObj = hit.collider.gameObject;
                var script = hit.collider.GetComponent<InteractableObject>();


                if (!isOnComputer)
                {
                    script.isLookingAt = true;
                    if(script.DisplaySprite)
                    {
                        var img = hudCanvas.GetComponentInChildren<Image>();
                        img.sprite = script.DisplaySprite;
                        img.color = hudImageColor;
                        hudCanvas.GetComponentInChildren<Text>().text = script.DisplayText;
                    }
                }

                if (Input.GetKeyDown(KeyCode.E))
                {
                    switch (script.DisplayText)
                    {
                        case "Computer":
                            if (canMove)
                            {
                                Cursor.lockState = CursorLockMode.None;
                                Cursor.visible = true;

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
            else if (hit.collider.tag == "TV")
            {
                if (Input.GetKeyDown(KeyCode.E))
                {
                    Cursor.lockState = CursorLockMode.None;
                    Cursor.visible = true;
                    currentTV = hit.collider.transform.parent.gameObject;
                    var script = hit.collider.GetComponentInParent<InteractableTV>();
                    canMove = false;
                    lastTVCam = script.gameObject.GetComponentInChildren<Camera>();
                    lastTVCam.GetComponent<PhysicsRaycaster>().enabled = true;
                    lastTVCam.enabled = true;
                    plyCam.enabled = false;
                    isRepairingTV = true;

                    invMng.RefreshInventory();
                    
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
    }
}
