using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreasureScript : MonoBehaviour {

    public GameObject[] loots;
    public Transform spawnPoint;

    private bool ChestOpened;
    
    private void OpenChest()
    {
        if (!ChestOpened)
        {
            for (int i = 0; i < loots.Length; i++)
            {
                GameObject item = Instantiate(loots[i], spawnPoint.position, spawnPoint.rotation) as GameObject;
            }
            ChestOpened = true;
        }
    }

    void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            if (Input.GetKeyDown(KeyCode.Space) && spawnPoint != null)
            {
                OpenChest();
            }
        }
    }
}
