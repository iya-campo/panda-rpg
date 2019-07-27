using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestObject : MonoBehaviour {

    public int questNumber;

    public string startText;
    public string endText;

    public bool isItemQuest;
    public string targetItem;

    public bool isEnemyQuest;
    public string targetEnemy;
    public int enemiesToKill;
    private int enemyKillCount;

    public QuestManager qManager;

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		if (isItemQuest)
        {
            if (qManager.itemCollected == targetItem)
            {
                qManager.itemCollected = null;
                EndQuest();
            }
        }
        if (isEnemyQuest)
        {
            if (qManager.enemyKilled == targetEnemy)
            {
                qManager.enemyKilled = null;
                enemyKillCount++;
            }
            if (enemyKillCount >= enemiesToKill)
            {
                EndQuest();
            }
        }
	}

    public void StartQuest()
    {
        qManager.ShowQuestText(startText);
    }

    public void EndQuest()
    {
        qManager.ShowQuestText(endText);
        qManager.questCompleted[questNumber] = true;
        gameObject.SetActive(false);
    }
}
