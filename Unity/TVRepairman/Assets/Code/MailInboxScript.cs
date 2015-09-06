using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class MailInboxScript : MonoBehaviour {

	public List<MailScript> mails = new List<MailScript>();
	public GameObject mailPrefab;
    public ReadMailScript readMails;

	// Use this for initialization
	void Start () {


        for (int i = 0; i < 5; i++)
        {
            mails.Add(GameObject.Find("Mail1").GetComponent<MailScript>());
            mails.Add(GameObject.Find("Mail2").GetComponent<MailScript>());

        }

        ReloadMails();
	}

	void ReloadMails()
	{
		foreach (Transform child in transform)
		{
			Destroy(child.gameObject);
		}
        //var scale = GetComponent<RectTransform>().sizeDelta;
        //float targetY = 65 * mails.Count;
        //if (scale.y < targetY)
        //    scale.y = targetY;
        //GetComponent<RectTransform>().sizeDelta = scale;


        for (int i = 0; i < mails.Count; i++)
		{
            GameObject m = (GameObject)Instantiate(mailPrefab);
            m.transform.SetParent(transform, false);

            var ms = m.GetComponent<MailScript>();
            ms.Body = mails[i].Body;
            ms.Subject = mails[i].Subject;
            ms.Sender = mails[i].Sender;
            ms.Setup();

            var pos = m.GetComponent<RectTransform>().localPosition;
            pos.y += -65 * i;
            m.GetComponent<RectTransform>().localPosition = pos;

            //var skala = m.GetComponent<RectTransform>().localScale;
            //skala.y = 0.5f;
            //m.GetComponent<RectTransform>().localScale = skala;

            ms.GetComponentInChildren<Button>().onClick.AddListener(delegate() { readMails.ReloadMail(ms); });
        }
    }
}
