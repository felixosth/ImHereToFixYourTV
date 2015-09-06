using UnityEngine;
using System.Collections;

public class InteractableObject : MonoBehaviour {

	public string DisplayText;

	public GameObject[] HideOrShowObjects;

	public bool isLookingAt;


	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

		if (isLookingAt)
		{
			for (int i = 0; i < HideOrShowObjects.Length; i++)
			{
				if (!HideOrShowObjects[i].activeInHierarchy)
					HideOrShowObjects[i].SetActive(true);
			}
		}
		else
		{
			for (int i = 0; i < HideOrShowObjects.Length; i++)
			{
				if (HideOrShowObjects[i].activeInHierarchy)
					HideOrShowObjects[i].SetActive(false);
			}
		}
	
	}
}
