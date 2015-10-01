using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class RepairTVScript : MonoBehaviour {

	public GameObject repairCanvas;

	public GameObject partMenuPrefab;

	GameObject menu;

	ObjectInteraction objInt;

	public GameObject inventoryPrefab;

	GameObject lastPart;

	// Use this for initialization
	void Start () {

		objInt = GetComponent<ObjectInteraction>();
	
	}
	
	// Update is called once per frame
	void Update () {

        if (repairCanvas)
        {

            var canvas = repairCanvas.GetComponent<Canvas>();
            if (objInt.isRepairingTV && !canvas.enabled)
            {
                repairCanvas.GetComponent<Canvas>().enabled = true;
            }
            else if (!objInt.isRepairingTV && canvas.enabled)
            {
                Destroy(menu);
                repairCanvas.GetComponent<Canvas>().enabled = false;

            }
        }
	}


	public void ClickPart(GameObject part)
	{
		if (menu)
		{
			if (lastPart == part)
			{
				Destroy(menu);

				menu = null;
				return;
			}
			else
				Destroy(menu);

		}

		lastPart = part;

		menu = (GameObject)Instantiate(partMenuPrefab);
		menu.transform.SetParent(repairCanvas.transform, false);
		menu.transform.position = Input.mousePosition + (new Vector3(menu.GetComponent<RectTransform>().rect.width, -menu.GetComponent<RectTransform>().rect.height, 0)/2);

		var partScript = part.GetComponent<TVPartScript>();


		var menuScript = menu.GetComponent<PartMenuScript>();
		menuScript.titleText.text = partScript.Name;

		menuScript.removeButton.onClick.AddListener(delegate () 
		{
			part.transform.parent.GetComponent<TvPartManager>().Remove(part);
			Destroy(menu);
		});
	}

    
		//var inv = Instantiate(inventoryPrefab) as GameObject;
		//inv.transform.SetParent(GameObject.Find("PartInventory").transform, false);
  //      var tvPartScript = part.GetComponent<TVPartScript>();
  //      inv.GetComponent<Text>().text = tvPartScript.Name + " - " + tvPartScript.Wear + "%";
  //      inv.GetComponent<InventoryPart>().Part = (GameObject)Instantiate(part);
        //inv.GetComponent<Button>().onClick.AddListener(delegate ()
        //{
        //    objInt.currentTV.GetComponent<TvPartManager>().AddPart(inv.GetComponent<InventoryPart>().Part);
        //});
}
