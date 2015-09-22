using UnityEngine;
using System.Collections;

public class TvPartManager : MonoBehaviour {

    public GameObject[] parts;
    string[] slotNames;
    Vector3[] partPositions;
    Vector3[] partScales;
    Quaternion[] partRotations;
    //public RepairTVScript tvScript;
    InventoryManagement invMng;

	// Use this for initialization
	void Start () {

        invMng = GameObject.Find("Player").GetComponent<InventoryManagement>();

        slotNames = new string[parts.Length];
        partPositions = new Vector3[parts.Length];
        partRotations = new Quaternion[parts.Length];
        partScales = new Vector3[parts.Length];

        for (int i = 0; i < parts.Length; i++)
        {
            var thePartPos = parts[i].transform.position;
            var thePartRot = parts[i].transform.rotation;
            var thePartScale = parts[i].transform.localScale;
            partPositions[i] = new Vector3(thePartPos.x, thePartPos.y, thePartPos.z);
            partRotations[i] = new Quaternion(thePartRot.x, thePartRot.y, thePartRot.z, thePartRot.w);
            partScales[i] = new Vector3(thePartScale.x, thePartScale.y, thePartScale.z);
            slotNames[i] = parts[i].GetComponent<TVPartScript>().Name;
        }
	}

    public void Remove(GameObject part)
    {
        for (int i = 0; i < parts.Length; i++)
        {
            if(parts[i] == part)
            {
                invMng.AddToInventory(part.name, true);
                Destroy(part);
            }
        }
    }

    public bool AddPart(string partName)
    {
        for (int i = 0; i < parts.Length; i++)
        {
            print(slotNames[i] + " " + parts[i]);
            if (partName == slotNames[i] && !parts[i])
            {
                parts[i] = (GameObject)Instantiate(invMng.GetPart(partName), partPositions[i], partRotations[i]);
                parts[i].transform.localScale = partScales[i];
                parts[i].transform.SetParent(transform);
                invMng.RefreshInventory();
                return true;
            }
        }
        return false;
    }
	
	// Update is called once per frame
	void Update () {
	
	}
}
