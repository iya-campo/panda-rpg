using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour {

    public float moveSpeed;
    public float timeBetweenMove;
    public float timeToMove;

    private float timeBetweenMoveCounter;
    private float timeToMoveCounter;

    private Vector3 moveDirection;
    private Rigidbody2D enemyRigidbody;
    private bool enemyMoving;

    public float stopDistance;
    public float enemyRadius;
    private Transform target;

    public bool CanAttack;
    
    // Use this for initialization
    void Start () {
        enemyRigidbody = GetComponent<Rigidbody2D>();

        timeBetweenMoveCounter = Random.Range(timeBetweenMove * 0.75f, timeBetweenMove * 1.25f);
        timeToMoveCounter = Random.Range(timeToMove * 0.75f, timeBetweenMove * 1.25f);

        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
    }
	
	// Update is called once per frame
	void Update ()
    {
        if (Vector2.Distance(transform.position, target.position) < enemyRadius)
        {
            if (Vector2.Distance(transform.position, target.position) > stopDistance)
            {
                transform.position = Vector2.MoveTowards(transform.position, target.position, moveSpeed * Time.deltaTime);
                if (target.gameObject.activeInHierarchy)
                {
                    CanAttack = true;
                }
                else
                {
                    CanAttack = false;
                }
            }
        }
        else
        {
            if (enemyMoving)
            {
                CanAttack = false;
                timeToMoveCounter -= Time.deltaTime;
                enemyRigidbody.velocity = moveDirection;
                if (timeToMoveCounter < 0f)
                {
                    enemyMoving = false;
                    timeBetweenMoveCounter = Random.Range(timeBetweenMove * 0.75f, timeBetweenMove * 1.25f);
                }
            }
            else
            {
                CanAttack = true;
                timeBetweenMoveCounter -= Time.deltaTime;
                enemyRigidbody.velocity = Vector2.zero;
                if (timeBetweenMoveCounter < 0f)
                {
                    enemyMoving = true;
                    timeToMoveCounter = Random.Range(timeToMove * 0.75f, timeBetweenMove * 1.25f);

                    moveDirection = new Vector3(Random.Range(-1f, 1f) * moveSpeed, Random.Range(-1f, 1f) * moveSpeed, 0f);
                }
            }
        }
    }
}
