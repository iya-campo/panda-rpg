using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestTrigger : MonoBehaviour {

    public int questNumber;

    public bool startQuest;
    public bool endQuest;

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
            if (!qManager.questCompleted[questNumber])
            {
                if (startQuest && !qManager.quests[questNumber].gameObject.activeSelf)
                {
                    qManager.quests[questNumber].gameObject.SetActive(true);
                    qManager.quests[questNumber].StartQuest();
                }
                if (endQuest && qManager.quests[questNumber].gameObject.activeSelf)
                {
                    qManager.quests[questNumber].EndQuest();
                }
            }
        }
    }
}
