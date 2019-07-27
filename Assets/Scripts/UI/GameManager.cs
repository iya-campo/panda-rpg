using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {

    [SerializeField]
    PlayerController player;

    public Transform MyTarget { get; set; }

    public GameObject lastTarget;

    public string respawnPoint;
    public float waitToReload;
    private GameObject thePlayer;
    private PlayerHealthManager playerHealth;

    void Start() {
        playerHealth = FindObjectOfType<PlayerHealthManager>();
        thePlayer = player.gameObject;
        lastTarget = null;
    }

    // Update is called once per frame
    void Update () {
        ClickTarget();
        if (playerHealth.playerCurrentHealth == 0)
        {
            Respawn();
        }
    }

    private void ClickTarget()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (lastTarget != null && lastTarget.tag != "Boss")
            {
                lastTarget.GetComponent<EnemyHealthManager>().OnDeselect();
            }

            RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero, Mathf.Infinity, 512);

            if (hit.collider != null)
            {
                if (hit.collider.tag == "Enemy")
                {
                    Debug.Log("Enemy");
                    lastTarget = hit.collider.gameObject;
                    player.MyTarget = hit.transform.GetChild(0);
                    hit.collider.GetComponent<EnemyHealthManager>().OnSelect();
                }
                if (hit.collider.tag == "Boss")
                {
                    Debug.Log("Boss");
                    lastTarget = hit.collider.gameObject;
                    player.MyTarget = hit.transform.GetChild(0);
                }
            }
            else
            {
                player.MyTarget = null;

            }
        }
    }

    private void Respawn()
    {
        waitToReload -= Time.deltaTime;
        if (waitToReload < 0)
        {
            SceneManager.LoadScene("main");
            playerHealth.playerCurrentHealth = playerHealth.playerMaxHealth;
            player.startPoint = respawnPoint;
            thePlayer.SetActive(true);

            waitToReload = 2;
        }
    }
}
