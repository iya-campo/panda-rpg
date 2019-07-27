using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTrigger : MonoBehaviour {

	public Dialogue dialogue;
    public GameObject gameObject;
    private SkipButton skipButton;

    private void Start()
    {
        skipButton = FindObjectOfType<SkipButton>();
    }

    public void TriggerDialogue ()
	{
        //gameObject.SetActive(FindObjectOfType<IntroDialogueManager>().skip);

        FindObjectOfType<IntroDialogueManager>().StartDialogue(dialogue);

	}

}
