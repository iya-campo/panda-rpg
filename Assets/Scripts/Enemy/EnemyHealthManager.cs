using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHealthManager : MonoBehaviour {

    public Image healthBar;
    public CanvasGroup canvasGroup;

    public int maxHealth;
    public int currentHealth;
    
    public int expToGive;

    public string enemyQuestName;

    public GameObject drop;
    public GameObject[] extraDrops;

    public int maxExtraDrop;

    private PlayerStats thePlayerStats;
    private QuestManager qManager;
    private SFXManager sManager;

    public GameObject damagePoof;
    public Transform hitBox;

    // Use this for initialization
    void Start()
    {
        currentHealth = maxHealth;

        thePlayerStats = FindObjectOfType<PlayerStats>();
        qManager = FindObjectOfType<QuestManager>();
        sManager = FindObjectOfType<SFXManager>();

        maxExtraDrop = Random.Range(0, maxExtraDrop);
    }

    // Update is called once per frame
    void Update()
    {
        float currentHealthFloat = currentHealth;
        healthBar.fillAmount = (currentHealthFloat)/maxHealth;
        OnDeath();
    }

    public void HurtEnemy(int damageToReceive)
    {
        currentHealth -= damageToReceive;
        sManager.attackImpact.Play();
    }

    public void setMaxHealth()
    {
        currentHealth = maxHealth;
    }

    public void OnDeath()
    {
        if (currentHealth <= 0)
        {
            qManager.enemyKilled = enemyQuestName;

            thePlayerStats.AddExperience(expToGive);

            EnemyLoot();
            
            Destroy(gameObject);
        }
    }

    public void EnemyLoot()
    {
        Instantiate(drop, transform.position, transform.rotation);

        for (int i = 0; i < maxExtraDrop; i++)
        {
            Instantiate(extraDrops[Random.Range(0, extraDrops.Length)], transform.position, transform.rotation);
        }
    }

    public void OnSelect()
    {
        canvasGroup.alpha = 1;
    }

    public void OnDeselect()
    {
        canvasGroup.alpha = 0;
    }
}