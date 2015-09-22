using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class TVPartScript : MonoBehaviour, IPointerClickHandler {

	public string Name;
    public int Wear = 100;
	GameObject player;

	public void OnPointerClick(PointerEventData eventData)
	{
		if(player.GetComponent<ObjectInteraction>().isRepairingTV)
			player.GetComponent<RepairTVScript>().ClickPart(gameObject);

	}

	// Use this for initialization
	void Start () {
		player = GameObject.Find("Player");
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
