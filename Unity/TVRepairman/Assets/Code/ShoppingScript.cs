using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ShoppingScript : MonoBehaviour {


    public RepairTVScript repTv;

    MoneyManagement moneyMng;

    public Text moneyDisplay;

    InventoryManagement inv;


	// Use this for initialization
	void Start () {

        inv = GameObject.Find("Player").GetComponent<InventoryManagement>();


        moneyMng = GameObject.Find("Player").GetComponent<MoneyManagement>();
	
	}
	
	// Update is called once per frame
	void Update () {
	
        moneyDisplay.text = string.Format("${0}", moneyMng.Money);
	}

    public void BuyPart(ShoppingItem item)
    {
        if(moneyMng.Buy(item.Cost))
        {
            print("buy successful");
            inv.AddToInventory(item.PartName);

        }
    }
}
