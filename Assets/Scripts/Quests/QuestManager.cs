using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestManager : MonoBehaviour {

    public QuestObject[] quests;
    public bool[] questCompleted;

    public string itemCollected;
    public string enemyKilled;

    public DialogueManager dManager;

    // Use this for initialization
    void Start () {
        questCompleted = new bool[quests.Length];
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void ShowQuestText(string questText)
    {
        dManager.dialogueLines = new string[1];
        dManager.dialogueLines[0] = questText;

        dManager.currentLine = 0;
        dManager.ShowDialogue();
    }
}
