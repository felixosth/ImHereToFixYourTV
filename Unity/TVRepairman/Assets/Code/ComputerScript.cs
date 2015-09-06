using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ComputerScript : MonoBehaviour {

	public GameObject blackPanel;
    public GameObject LoginPanel;
    public GameObject DesktopPanel;


    // Use this for initialization
    void Start () {


	
	}
	
	// Update is called once per frame
	void Update () {
	
	}


    public void On()
    {
        blackPanel.SetActive(false);
        LoginPanel.SetActive(true);
    }

    public void Off()
    {
        blackPanel.SetActive(true);
        LoginPanel.SetActive(false);

    }

    public void Login()
    {
        LoginPanel.SetActive(false);
        DesktopPanel.SetActive(true);
    }

    public void Logout()
    {
        LoginPanel.SetActive(true);
        DesktopPanel.SetActive(false);
    }


}
