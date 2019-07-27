using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "HealthItem", menuName = "Items/Health Item", order = 1)]
public class HealthItem : Item, IUseable
{

    [SerializeField]
    private int health;

    private bool HasExcess;

    public void Use()
    {
        if (true)
        {
            if (PlayerHealthManager.MyInstance.playerCurrentHealth < PlayerHealthManager.MyInstance.playerMaxHealth && (PlayerHealthManager.MyInstance.playerMaxHealth - PlayerHealthManager.MyInstance.playerCurrentHealth) < health)
            {
                Remove();
                PlayerHealthManager.MyInstance.playerCurrentHealth += PlayerHealthManager.MyInstance.playerMaxHealth - PlayerHealthManager.MyInstance.playerCurrentHealth;
                HasExcess = true;
            }
            if (PlayerHealthManager.MyInstance.playerCurrentHealth < PlayerHealthManager.MyInstance.playerMaxHealth && !HasExcess)
            {
                Remove();
                PlayerHealthManager.MyInstance.playerCurrentHealth += health;
            }
        }
    }
}
