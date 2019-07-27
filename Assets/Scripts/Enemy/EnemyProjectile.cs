using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyProjectile : MonoBehaviour {

    private Rigidbody2D myRigidBody;
    
    public int speed;

    public float range;

    public Transform MyTarget;

    // Use this for initialization
    void Start () {
        myRigidBody = GetComponent<Rigidbody2D>();
        Destroy(gameObject, range);
    }

    private void FixedUpdate ()
    {
        MyTarget = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();

        Vector2 direction = MyTarget.position - transform.position;

        myRigidBody.velocity = direction.normalized * speed;

        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

        transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
    }
}
