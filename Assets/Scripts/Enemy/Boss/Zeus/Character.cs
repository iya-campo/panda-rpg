using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(Animator))]
public abstract class Character : MonoBehaviour {

    [SerializeField]
    protected float speed;

    protected Vector2 direction;
    protected Animator myAnimator;

    private Rigidbody2D myRigidbody;
    protected bool isAttacking = false;

    protected bool swing = false;
    private Swing isSwing;

    public bool IsMoving
    {
        get
        {
            return direction.x != 0 || direction.y != 0;
        }
    }

	// Use this for initialization
	protected virtual void Start () {
        myRigidbody = GetComponent<Rigidbody2D>();
        myAnimator = GetComponent<Animator>();
        isSwing = FindObjectOfType<Swing>();
	}
	
	// Update is called once per frame
	protected virtual void Update () {
        HandleLayers();  
	}

    private void FixedUpdate()
    {
        Move();
    }

    public void Move()
    {
        myRigidbody.velocity = direction.normalized * speed;
        
    }

    public void HandleLayers()
    {
        if (IsMoving)
        {
            ActivateLayer("WalkLayer");
            
            myAnimator.SetFloat("X", direction.x);
            myAnimator.SetFloat("Y", direction.y);
            if (isSwing.entered)
            {
                ActivateLayer("SwingLayer");
            }
            

        } 
        else
        {
            ActivateLayer("IdleLayer");
        }
    }


    public void ActivateLayer(string layerName)
    {
        for(int i = 0; i < myAnimator.layerCount; i++)
        {
            myAnimator.SetLayerWeight(i, 0);
        }

        myAnimator.SetLayerWeight(myAnimator.GetLayerIndex(layerName), 1);
    }
}
