﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectiveTrigger1 : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.name == "Player")
        {
            Debug.Log("Hatdog");
        }
    }
}
