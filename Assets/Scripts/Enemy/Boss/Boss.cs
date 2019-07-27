using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Boss : MonoBehaviour {

    public int maxHealth;
    public int currentHealth;
    public Slider healthBar;

    public int expToGive;

    public string enemyQuestName;

    public GameObject lootDrop;

    private PlayerStats thePlayerStats;
    private QuestManager qManager;
    private float timeDamage = 1.5f;

    //public Animator redPanel;
    // public Animator camAnim;

    public float speed;
    public float stoppingDistance;
    public float retreatDistance;
    private Transform player;

    private float timeBtwShots;
    public float startTimeBtwShots;

    public GameObject projectile;
    public GameObject projectile2;
    protected Vector2 direction;
    private Animator anim;
    public Vector2 lastMove;
    private bool playerMoving;
    private bool attacking;
    public float attackTime;
    private float attackCounter;

    public GameObject drop;
    public GameObject[] extraDrops;

    public int maxExtraDrop;

    private MainStory mainStory;


    // Use this for initialization
    void Start()
    {
        currentHealth = maxHealth;

        healthBar.maxValue = maxHealth;
        player = GameObject.FindGameObjectWithTag("Player").transform;
        thePlayerStats = FindObjectOfType<PlayerStats>();
        timeBtwShots = startTimeBtwShots;
        qManager = FindObjectOfType<QuestManager>();
        anim = GetComponent<Animator>();
        mainStory = FindObjectOfType<MainStory>();
    }

    // Update is called once per frame
    void Update()
    {
        attacking = anim.GetBool("Attack");
        if (!attacking) { 
            
            if (currentHealth <= 0)
            {
                qManager.enemyKilled = enemyQuestName;

                gameObject.SetActive(false);

                thePlayerStats.AddExperience(expToGive);

                Instantiate(lootDrop, transform.position, Quaternion.identity);
            }
        }
        if (attacking) {
                if (timeBtwShots <= 0)
                {
                    if (currentHealth <= maxHealth && currentHealth >= maxHealth / 2)
                     {
                         Instantiate(projectile, transform.position, Quaternion.identity);
                     }
                     else
                        {
                          Instantiate(projectile2, transform.position, Quaternion.identity);
                        }
                    timeBtwShots = startTimeBtwShots;
                }
                else
                {
                    timeBtwShots -= Time.deltaTime;
                }
            }
            healthBar.value = currentHealth;
        if (attackCounter > 0)
        {
            attackCounter -= Time.deltaTime;
        }
        if (attackCounter <= 0)
        {
            attacking = false;
            anim.SetBool("Attack", false);
        }
        OnDeath();
    }

    public void HurtEnemy(int damageToGive)
    {
        currentHealth -= damageToGive;
    }

    public void setMaxHealth()
    {
        currentHealth = maxHealth;
    }

    private void FollowTarget()
    {
        transform.position = Vector2.MoveTowards(transform.position, player.position, speed * Time.deltaTime);
        direction = (player.transform.position - transform.position).normalized;
        playerMoving = true;
        attacking = true;
    }

    public void OnDeath()
    {
        if (currentHealth <= 0)
        {
            qManager.enemyKilled = enemyQuestName;

            thePlayerStats.AddExperience(expToGive);

            EnemyLoot();

            Destroy(gameObject);

            mainStory.BossKilled = true;
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
}
