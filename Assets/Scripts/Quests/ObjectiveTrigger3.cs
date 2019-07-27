using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectiveTrigger3 : MonoBehaviour {

    private MainStory mainStory;

    // Use this for initialization
    void Start () {
        mainStory = FindObjectOfType<MainStory>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.name == "Player")
        {
            mainStory.IsInOlympus = true;
        }
    }
}
