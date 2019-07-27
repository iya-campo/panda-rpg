using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealthManager : MonoBehaviour {

    public int maxHealth;
    public int currentHealth;
    
    public int expToGive;

    public string enemyQuestName;

    public GameObject lootDrop;

    private PlayerStats thePlayerStats;
    private QuestManager qManager;

    // Use this for initialization
    void Start()
    {
        currentHealth = maxHealth;

        thePlayerStats = FindObjectOfType<PlayerStats>();
        qManager = FindObjectOfType<QuestManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (currentHealth <= 0)
        {
            qManager.enemyKilled = enemyQuestName;

            gameObject.SetActive(false);

            thePlayerStats.AddExperience(expToGive);

            Instantiate(lootDrop, transform.position, Quaternion.identity);
        }
    }

    public void HurtEnemy(int damageToGive)
    {
        currentHealth -= damageToGive;
    }

    public void setMaxHealth()
    {
        currentHealth = maxHealth;
    }
}
