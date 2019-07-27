using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkipButton : MonoBehaviour {
    
    private IntroDialogueManager introDialogueManager;
    public GameObject gameObject;

	// Use this for initialization
	void Start () {
        introDialogueManager = FindObjectOfType<IntroDialogueManager>();

        Debug.Log("Hello");
    }
	
	// Update is called once per frame
	void Update () {
        gameObject.SetActive(introDialogueManager.skip);
	}


}
