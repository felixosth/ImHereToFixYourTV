using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ComputerScript : MonoBehaviour {

	public GameObject blackPanel;
    public GameObject LoginPanel;
    public GameObject DesktopPanel;
    public GameObject MailPanel;


    // Use this for initialization
    void Start () {


	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void ExitEmail()
    {
        DesktopPanel.SetActive(true);
        MailPanel.SetActive(false);
    }

    public void OpenEmail()
    {
        DesktopPanel.SetActive(false);
        MailPanel.SetActive(true);
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
