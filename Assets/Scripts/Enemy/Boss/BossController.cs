using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BossController : Character {

    
    public float timeBetweenMove;
    public float timeToMove;
    public float waitToReload;

    private float timeBetweenMoveCounter;
    private float timeToMoveCounter;
    private bool reloading;

    private GameObject thePlayer;
    private Vector3 moveDirection;
    private Rigidbody2D enemyRigidbody;
    private bool enemyMoving;

    public float stopDistance;
    public float enemyRadius;
    private Transform target;

    public Transform Target
    {
        get
        {
            return target;
        }

        set
        {
            target = value;
        }
    }

    public GameObject damagePoof;
    public Transform hitBox;

    //attack
    private bool attacking;
    public float attackTime;
    private float attackCounter;

    public Transform MyTarget { get; set; }
    public GameObject thunderBall;
    public GameObject thunderBolt;
    private Projectile damage;

    private int rand;
    private Swing isSwinging;
    private bool swingggg;

    private Boss boss;
    private Transform player;
    protected override void Start()
    {
        isSwinging = FindObjectOfType<Swing>();
        base.Start();
        swingggg = isSwinging.entered;
        boss = GetComponent<Boss>();
        damage = FindObjectOfType<Projectile>();
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }
    // Update is called once per frame
    protected override void Update()
    {
        
        if (reloading)
        {
            waitToReload -= Time.deltaTime;
            if (waitToReload < 0)
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
                thePlayer.SetActive(true);
            }
        }
        FollowTarget();
        base.Update();
        if (swingggg)
        {
            swing = true;
        }
        isAttacking = true;
        myAnimator.SetBool("Attack", true);
       
    }
    private void Attack(GameObject projectile)
    {
       Instantiate(projectile); 
    }

    
    private void FollowTarget()
    {
        rand = Random.Range(0, 2);
        if(target != null)
        {
            direction = (target.transform.position - transform.position).normalized;
            transform.position = Vector2.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
        }
        else
        {
            direction = Vector2.zero;
            //random movements
        }
    }

    private void RetreatFromTarget()
    {
        transform.position = Vector2.MoveTowards(transform.position, player.position, speed * Time.deltaTime);
    }
}
