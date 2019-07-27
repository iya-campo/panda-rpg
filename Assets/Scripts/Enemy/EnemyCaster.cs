using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCaster : MonoBehaviour {

    private Transform target;

    public float timeToAttack;
    public float timeBetweenAttack;

    public GameObject projectile;

    private EnemyController enemyController;

    // Use this for initialization
    void Start () {
        enemyController = GetComponent<EnemyController>();
        timeToAttack = timeBetweenAttack;
    }
	
	// Update is called once per frame
	void Update ()
    {
        if (enemyController.CanAttack)
        {
            EnemyAttack();
        }
    }

    private void EnemyAttack()
    {
        timeToAttack -= Time.deltaTime;
        if (timeToAttack < 0f)
        {
            Instantiate(projectile, transform.position, Quaternion.identity);
            timeToAttack = timeBetweenAttack;
        }
    }
}
