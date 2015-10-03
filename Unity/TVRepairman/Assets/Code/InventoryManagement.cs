using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class InventoryItemCollection
{

    public InventoryItemCollection(string type)
    {
        this.Type = type;
    }
    public string Type;
    public int Count = 1;
}

public class InventoryManagement : MonoBehaviour {


    List<GameObject> guiItems = new List<GameObject>();

    public GameObject[] partPrefabs;

    public GameObject invPrefab;
    List<InventoryItemCollection> items = new List<InventoryItemCollection>();

    public void AddToInventory(string partName, bool instantRefresh = false)
    {
        if (items.Count == 0)
        {
            items.Add(new InventoryItemCollection(partName.Replace("(Clone)", "")));
        }
        else
        {
            for (int i = 0; i < items.Count; i++)
            {
                if (items[i].Type == partName.Replace("(Clone)", ""))
                {
                    items[i].Count++;
                    break;
                }
                else if (i == items.Count - 1)
                {
                    items.Add(new InventoryItemCollection(partName.Replace("(Clone)", "")));
                    break;
                }
            }
        }


        if (instantRefresh)
            RefreshInventory();

    }

    public GameObject GetPart(string partName)
    {
        foreach (GameObject obj in partPrefabs)
        {
            if (partName == obj.name)
            {
                for (int i = 0; i < items.Count; i++)
                {
                    if (partName == items[i].Type)
                        items[i].Count--;
                }
                return obj;

            }
        }
        throw new System.Exception("No part with that name :(");
    }

    public void RefreshInventory()
    {
        foreach (GameObject obj in guiItems)
        {
            Destroy(obj);
        }
        guiItems.Clear();

        foreach (InventoryItemCollection col in items)
        {
            if (col.Count > 0)
            {

                var inv = Instantiate(invPrefab) as GameObject;
                inv.transform.SetParent(GameObject.Find("PartInventory").transform, false);
                inv.GetComponent<Text>().text = col.Type + ": " + col.Count;
                inv.GetComponent<InventoryPart>().PartName = col.Type;

                guiItems.Add(inv);
            }
        }
    }

    public int GetItemCount(string partName)
    {
        foreach (InventoryItemCollection col in items)
        {
            if (col.Type == partName)
                return col.Count;
        }
        throw new System.Exception("No part with that name :(");
    }

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
