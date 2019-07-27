using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HurtEnemy : MonoBehaviour {

    public int damageToGive;
    public int currentDamage;

    public GameObject damageNumber;
    public GameObject damageBurst;
    public Transform hitPoint;

    private PlayerStats thePlayerStats;

	// Use this for initialization
	void Start () {
        thePlayerStats = FindObjectOfType<PlayerStats>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Enemy")
        {
            currentDamage = damageToGive + thePlayerStats.currentAttack;
            other.gameObject.GetComponent<EnemyHealthManager>().HurtEnemy(currentDamage);
            
            Instantiate(damageBurst, hitPoint.position, hitPoint.rotation);

            var clone = (GameObject) Instantiate(damageNumber, hitPoint.position, Quaternion.Euler(Vector3.zero));
            clone.GetComponent<FloatingNumbers>().damageNumber = currentDamage;
        }
        if(other.gameObject.tag == "Boss")
        {
            currentDamage = damageToGive + thePlayerStats.currentAttack;
            other.gameObject.GetComponent<Boss>().HurtEnemy(currentDamage);

            Instantiate(damageBurst, hitPoint.position, hitPoint.rotation);

            var clone = (GameObject)Instantiate(damageNumber, hitPoint.position, Quaternion.Euler(Vector3.zero));
            clone.GetComponent<FloatingNumbers>().damageNumber = currentDamage;
        }
    }
}
