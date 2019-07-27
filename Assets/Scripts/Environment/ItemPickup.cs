using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemPickup : MonoBehaviour {

    public int lootIndex;
    private InventoryScript myInventory;

	// Use this for initialization
	void Start () {
        myInventory = FindObjectOfType<InventoryScript>();
	}
	
	// Update is called once per frame
	void Update () {

    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.name == "Player")
        {
            myInventory.PlaceItemInBag(lootIndex);

            Destroy(gameObject);
        }
    }
}
