using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BossSlider : MonoBehaviour {

    public Slider healthBar;
    public Boss bossHealth;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        healthBar.maxValue = bossHealth.maxHealth;
        healthBar.value = bossHealth.currentHealth;
    }
}
