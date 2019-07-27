using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HurtEnemyOnCast : MonoBehaviour
{

    private int damageToGive;
    private int currentDamage;

    public GameObject damageNumber;
    public GameObject damagePoof;
    private Transform hitBox;

    private PlayerStats thePlayerStats;

    // Use this for initialization
    void Start()
    {
        thePlayerStats = FindObjectOfType<PlayerStats>();
        hitBox = FindObjectOfType<GameManager>().lastTarget.transform;
        damageToGive = GetComponent<SpellScript>().damageToGive;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Enemy")
        {
            currentDamage = damageToGive + thePlayerStats.currentAttack;
            other.gameObject.GetComponent<EnemyHealthManager>().HurtEnemy(currentDamage);
            Destroy(gameObject);

            Instantiate(damagePoof, hitBox.position, hitBox.rotation);

            var clone = (GameObject)Instantiate(damageNumber, hitBox.position, Quaternion.Euler(Vector3.zero));
            clone.GetComponent<FloatingNumbers>().damageNumber = currentDamage;
        }
        if (other.gameObject.tag == "Boss")
        {
            currentDamage = damageToGive + thePlayerStats.currentAttack;
            other.gameObject.GetComponent<Boss>().HurtEnemy(currentDamage);
            Destroy(gameObject);

            Instantiate(damagePoof, hitBox.position, hitBox.rotation);

            var clone = (GameObject)Instantiate(damageNumber, hitBox.position, Quaternion.Euler(Vector3.zero));
            clone.GetComponent<FloatingNumbers>().damageNumber = currentDamage;
        }
    }
}
