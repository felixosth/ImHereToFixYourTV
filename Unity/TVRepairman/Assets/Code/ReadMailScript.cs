using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ReadMailScript : MonoBehaviour {

	public Text SubjectText;
	public Text SenderText;
	public Text BodyText;


	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}


    public void ReloadMail(MailScript mail)
    {
        SubjectText.text = mail.Subject;
        SenderText.text = "From: " + mail.Sender;
        BodyText.text = mail.Body;
        mail.Read();
    }


}
