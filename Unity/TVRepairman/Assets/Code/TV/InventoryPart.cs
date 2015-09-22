using UnityEngine;
using System.Collections;

public class InventoryPart : MonoBehaviour {

    public string PartName;
    public ObjectInteraction objInt;
    InventoryManagement invMng;

	// Use this for initialization
	void Start () {
        objInt = GameObject.Find("Player").GetComponent<ObjectInteraction>();
        invMng = objInt.gameObject.GetComponent<InventoryManagement>();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void AddPartToTv()
    {
        if (objInt.currentTV.GetComponent<TvPartManager>().AddPart(PartName) && invMng.GetItemCount(PartName) <= 0)
        {
            Destroy(gameObject);
        }
    }
}
