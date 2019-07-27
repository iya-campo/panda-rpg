using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestItem : MonoBehaviour {

    public int questNumber;

    public string itemName;

    private QuestManager qManager;

	// Use this for initialization
	void Start () {
        qManager = FindObjectOfType<QuestManager>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.name == "Player")
        {
            if (!qManager.questCompleted[questNumber] && qManager.quests[questNumber].gameObject.activeSelf)
            {
                qManager.itemCollected = itemName;
                gameObject.SetActive(false);
            }
        }
    }
}
