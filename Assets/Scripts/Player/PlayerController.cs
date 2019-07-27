using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    public float moveSpeed;
    private float currentMoveSpeed;
    public Vector2 lastMove;
    private Vector2 moveInput;

    private Animator anim;
    private Rigidbody2D playerRigidbody;
    private bool playerMoving;
    private static bool playerExists;

    public float attackTime;
    private float attackTimeCounter;
    private bool attacking;
    public bool canMove;

    public string startPoint;
    
    private SFXManager sManager;

    public Transform MyTarget { get; set; }

    private int exitIndex = 2;

    private SpellBook spellBook;

    private Coroutine castRoutine;

    [SerializeField]
    private Block[] blocks;

    private static PlayerController instance;

    public static PlayerController MyInstance
    {
        get
        {
            if (instance == null)
            {
                instance = FindObjectOfType<PlayerController>();
            }
            return instance;
        }
    }

    // Use this for initialization
    void Start() {
        spellBook = GetComponent<SpellBook>();
        anim = GetComponent<Animator>();
        playerRigidbody = GetComponent<Rigidbody2D>();
        sManager = FindObjectOfType<SFXManager>();

        if (!playerExists)
        {
            playerExists = true;
            DontDestroyOnLoad(transform.gameObject);
        } else
        {
            Destroy(gameObject);
        }
        canMove = true;
        lastMove = new Vector2(0, -1f);
        
        Block();
    }

    // Update is called once per frame
    void Update() {
        playerMoving = false;
        if (!canMove)
        {
            playerRigidbody.velocity = Vector2.zero;
            return;
        }
        if (!attacking)
        {
            //Player Movement
            moveInput = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical")).normalized;
            if (moveInput != Vector2.zero)
            {
                playerRigidbody.velocity = new Vector2(moveInput.x * moveSpeed, moveInput.y * moveSpeed);
                playerMoving = true;
                lastMove = moveInput;
            } else
            {
                playerRigidbody.velocity = Vector2.zero;
            }
            anim.SetFloat("MoveX", Input.GetAxisRaw("Horizontal"));
            anim.SetFloat("MoveY", Input.GetAxisRaw("Vertical"));
            anim.SetFloat("LastMoveX", lastMove.x);
            anim.SetFloat("LastMoveY", lastMove.y);
            anim.SetBool("PlayerMoving", playerMoving);

            //Player Actions
            if (Input.GetKeyDown(KeyCode.Space))
            {
                Attack();
            }
        }
        if (attackTimeCounter > 0)
        {
            attackTimeCounter -= Time.deltaTime;
        }
        if (attackTimeCounter <= 0)
        {
            attacking = false;
            anim.SetBool("Attack", false);
        }
        GetInput();
        Block();
    }

    private void GetInput()
    {
        if (Input.GetKeyDown(KeyCode.W))
        {
            exitIndex = 0;
        }
        if (Input.GetKeyDown(KeyCode.A))
        {
            exitIndex = 3;
        }
        if (Input.GetKeyDown(KeyCode.S))
        {
            exitIndex = 2;
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            exitIndex = 1;
        }
    }


    public void Attack()
    {
        attackTimeCounter = attackTime;
        attacking = true;
        playerRigidbody.velocity = Vector2.zero;
        anim.SetBool("Attack", true);
        sManager.playerAttack.Play();
    }
    

    private IEnumerator CastSpell(int spellIndex)
    {
        Transform currentTarget = MyTarget;
        StopAttack();
        if (currentTarget != null && InLineOfSight())
        {
            canMove = false;
            anim.SetBool("Attack", true);
            Spell newSpell = spellBook.CastSpell(spellIndex);
            yield return new WaitForSeconds(newSpell.MyCastTime);
            SpellScript s = Instantiate(newSpell.MySpellPrefab, transform.position, Quaternion.identity).GetComponent<SpellScript>();
            s.MyTarget = currentTarget;
        }
        canMove = true;
    }

    public void Casting(int spellIndex)
    {
        castRoutine = StartCoroutine(CastSpell(spellIndex));
    }

    public void StopAttack()
    {
        if (castRoutine != null)
        {
            StopCoroutine(castRoutine);
            castRoutine = null;
        }
    }

    private bool InLineOfSight()
    {
        Vector3 targetDirection = (MyTarget.transform.position - transform.position).normalized;
        RaycastHit2D hit = Physics2D.Raycast(transform.position, targetDirection, Vector2.Distance(transform.position, MyTarget.transform.position), 256);
        if (hit.collider == null)
        {
            return true;
        }
        return false;
    }

    private void Block()
    {
        foreach (Block b in blocks)
        {
            b.Deactivate();
        }
        blocks[exitIndex].Activate();
    }
}
