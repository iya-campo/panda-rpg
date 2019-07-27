using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueHolder : MonoBehaviour {

    public string dialogue;
    public string[] dialogueLines;
    private DialogueManager dManager;

	// Use this for initialization
	void Start () {
        dManager = FindObjectOfType<DialogueManager>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.name == "Player")
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                //dManager.ShowBox(dialogue);
                if (!dManager.dialogueActive)
                {
                    dManager.dialogueLines = dialogueLines;
                    dManager.currentLine = 0;
                    dManager.ShowDialogue();
                }
                if (transform.parent.GetComponent<VillagerMovement>() != null)
                {
                    transform.parent.GetComponent<VillagerMovement>().canMove = false;
                }
            }
        }
    }
}
