using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpellScript : MonoBehaviour {

    private Rigidbody2D myRigidBody;

    private int damage;

    public int damageToGive;
    
    public int speed;

    public float range;

    public Transform MyTarget { get; set; }
    
    // Use this for initialization
    void Start () {
        myRigidBody = GetComponent<Rigidbody2D>();
        Destroy(gameObject, range);
    }

    private void FixedUpdate ()
    {
        if (MyTarget != null)
        {
            Vector2 direction = MyTarget.position - transform.position;

            myRigidBody.velocity = direction.normalized * speed;

            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

            transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        }
    }
}
