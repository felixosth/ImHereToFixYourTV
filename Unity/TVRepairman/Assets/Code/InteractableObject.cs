using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.Events;

[System.Serializable]
public class MyEvent : UnityEvent { }

public class InteractableObject : MonoBehaviour {

	public string DisplayText;
    public Sprite DisplaySprite;


    public GameObject[] HideOrShowObjects;

	public bool isLookingAt;


    public MyEvent onClickEvent;
    public string arg;

    
    public bool isDoor;
    bool isClosed = true;

    Animator anim;




	// Use this for initialization
	void Start () {
        
        if(isDoor)
        {
            anim = GetComponent<Animator>();

            
        }
	}
	
	// Update is called once per frame
	void Update () {

		if (isLookingAt && HideOrShowObjects.Length > 0)
		{
			for (int i = 0; i < HideOrShowObjects.Length; i++)
			{
				if (!HideOrShowObjects[i].activeInHierarchy)
					HideOrShowObjects[i].SetActive(true);
			}
		}
		else if(HideOrShowObjects.Length > 0)
		{
			for (int i = 0; i < HideOrShowObjects.Length; i++)
			{
				if (HideOrShowObjects[i].activeInHierarchy)
					HideOrShowObjects[i].SetActive(false);
			}
		}

        if (isLookingAt && Input.GetKeyDown(KeyCode.E) && isDoor)
        {
            if (isClosed)
            {
                anim.SetTrigger("Open");
                isClosed = false;
            }
            else
            {
                anim.SetTrigger("Close");
                isClosed = true;
            }
        }
        else if (Input.GetKeyDown(KeyCode.E) && onClickEvent != null && isLookingAt)
        {
            onClickEvent.Invoke();
        }
	
	}

    public void LoadLevel(string level)
    {
        Application.LoadLevel(level);
    }
}
