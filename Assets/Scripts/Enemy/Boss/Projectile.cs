using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Projectile : MonoBehaviour {

    public float speed;

    private Transform player;
    private Vector2 target;

    public int damageToGive; 
    private int currentDamage;
    private PlayerStats playerStats;
    private Rigidbody2D rb;
    public float rotateSpeed;
    public float secondsBeforeDestroy;
    private Boss boss;

    // Use this for initialization
    void Start () {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        playerStats = FindObjectOfType<PlayerStats>();
        target = new Vector2(player.position.x, player.position.y);
        rb = GetComponent<Rigidbody2D>();
        boss = FindObjectOfType<Boss>();
        damageToGive = 5;
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        Vector2 direction = (Vector2)player.position - rb.position;
        direction.Normalize();
        float rotateAmount = Vector3.Cross(direction, transform.up).z;
        rb.angularVelocity = -rotateAmount * rotateSpeed;
        rb.velocity = transform.up * speed;
	}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        DestroyProjectile();
        if (collision.CompareTag("Player"))
        {
            Destroy(gameObject);
            currentDamage = damageToGive - playerStats.currentDefense;
            if (currentDamage < 0)
            {
                currentDamage = 0;
            }
            if(boss.currentHealth <= 399)
            {
                damageToGive += 10;
                secondsBeforeDestroy += 2;
            }
            collision.gameObject.GetComponent<PlayerHealthManager>().HurtPlayer(currentDamage);
        }
    }

    void DestroyProjectile()
    {
        Destroy(gameObject, secondsBeforeDestroy);
    }
}
