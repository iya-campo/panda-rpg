using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnterShop : MonoBehaviour {

    private ShopScript shopScript;

	// Use this for initialization
	void Start () {
        shopScript = FindObjectOfType<ShopScript>();
	}
	
	// Update is called once per frame
	void Update () {

    }

    void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                shopScript.OpenClose();
            }   
        }
    }
}
