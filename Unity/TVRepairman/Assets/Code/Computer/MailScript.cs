using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class MailScript : MonoBehaviour {

    public Color hasReadColor;

    public string Subject;
    public string Body;
    public string Sender;
    public bool isMission = false;
    public string MissionTarget;

    public Text SubjectText;
    public Text SenderText;

    // Use this for initialization
    void Start () {

    

    }

    public void Setup()
    {
        
        SenderText.text = "From: " + Sender;
        SubjectText.text = Subject;
    }
    
    // Update is called once per frame
    void Update () {
    
    }

    public void Read()
    {
        GetComponent<Image>().color = hasReadColor;
    }
}
