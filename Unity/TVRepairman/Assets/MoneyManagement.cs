using UnityEngine;
using System.Collections;

public class MoneyManagement : MonoBehaviour {

    public int Money;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public bool Buy(int cost)
    {
        if (cost <= Money)
        {
            Money -= cost;
            return true;
        }
        return false;
    }
}
