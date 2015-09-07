using UnityEngine;
using System.Collections;
using System.Text.RegularExpressions;

public class MailBankScript : MonoBehaviour {

	public MailScript[] Mails;
    public TextAsset[] mailFiles;

	// Use this for initialization
	void Start () {

		for (int i = 0; i < Mails.Length; i++)
		{
            string[] splitMail = mailFiles[i].text.Split('|');
			Mails[i].Subject = splitMail[0];
			Mails[i].Sender = splitMail[1];
			Mails[i].Body = splitMail[2];
            if (splitMail.Length == 4)
            {
                Mails[i].isMission = true;
                Mails[i].MissionTarget = splitMail[3];
            }
		}
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
