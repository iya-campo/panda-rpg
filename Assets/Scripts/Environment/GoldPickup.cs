using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoldPickup : MonoBehaviour {

    public int value;
    private MoneyManager monManager;

	// Use this for initialization
	void Start () {
        monManager = FindObjectOfType<MoneyManager>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.name == "Player")
        {
            monManager.AddMoney(value);
            Destroy(gameObject);
        }
    }
}
