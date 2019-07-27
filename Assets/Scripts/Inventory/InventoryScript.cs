using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryScript : MonoBehaviour {

    private int bonesCount, beefCount, entrailsCount = 0;
    public bool CompleteLoot;

    private bool bagExists;

    private MainStory mainStory;

    private static InventoryScript instance;

    public static InventoryScript MyInstance
    {
        get
        {
            if (instance == null)
            {
                instance = FindObjectOfType<InventoryScript>();
            }
            return instance;
        }
    }

    private List<Bag> bags = new List<Bag>();

    [SerializeField]
    private BagButton[] bagButtons;

    //For debugging
    [SerializeField]
    public Item[] items;

    public bool CanAddBag
    {
        get { return bags.Count < 1; }
    }
    
    public void Update()
    {
        mainStory = FindObjectOfType<MainStory>();
        Bag bag = (Bag)Instantiate(items[0]);
        bag.Initialize(16);
        bag.Use();
        if (!bagExists)
        {
            bag.MyBagScript.OpenClose();
            bagExists = true;
        }
    }

    public void PlaceItemInBag(int itemIndex)
    {
        switch (itemIndex)
        {
            case 0:
                Bag bag = (Bag)Instantiate(items[0]);
                AddItem(bag);
                break;
            case 1:
                HealthPotion potion = (HealthPotion)Instantiate(items[1]);
                AddItem(potion);
                break;
            case 2:
                HealthItem apple = (HealthItem)Instantiate(items[2]);
                AddItem(apple);
                break;
            case 3:
                Loot beef = (Loot)Instantiate(items[3]);
                AddItem(beef);
                beefCount++;
                if (beefCount >= 1)
                {
                    mainStory.BeefComplete = true;
                }
                break;
            case 4:
                Loot bones = (Loot)Instantiate(items[4]);
                AddItem(bones);
                bonesCount++;
                if (bonesCount >= 1)
                {
                    mainStory.BonesComplete = true;
                }
                break;
            case 5:
                Loot entrails = (Loot)Instantiate(items[5]);
                AddItem(entrails);
                entrailsCount++;
                if (entrailsCount >= 1)
                {
                    mainStory.EntrailsComplete = true;
                }
                break;
            case 6:
                Weapon sword1 = (Weapon)Instantiate(items[6]);
                AddItem(sword1);
                break;
        }
    }

    public void InstantiateCrates()
    {
        KeyItem crate1 = (KeyItem)Instantiate(items[7]);
        AddItem(crate1);
        KeyItem crate2 = (KeyItem)Instantiate(items[8]);
        AddItem(crate2);
    }

    public void AddBag(Bag bag)
    {
        foreach (BagButton bagButton in bagButtons)
        {
            if (bagButton.MyBag == null)
            {
                bagButton.MyBag = bag;
                bags.Add(bag);
                break;
            }
        }
    }

    public void AddItem(Item item)
    {
        if (item.MyStackSize > 0)
        {
            if (PlaceInStack(item))
            {
                return;
            }
        }
        PlaceInEmpty(item);
    }

    private void PlaceInEmpty(Item item)
    {
        foreach (Bag bag in bags)
        {
            if (bag.MyBagScript.AddItem(item))
            {
                return;
            }
        }
    }

    private bool PlaceInStack(Item item)
    {
        foreach (Bag bag in bags)
        {
            foreach (SlotScript slots in bag.MyBagScript.MySlots)
            {
                if (slots.StackItem(item))
                {
                    return true;
                }
            }
        }
        return false;
    }

    public void OpenClose()
    {
        bool closedBag = bags.Find(x => !x.MyBagScript.IsOpen);

        //If closed bag == true, then open all closed bags
        //If closed bag == false, then close all open bags

        foreach (Bag bag in bags)
        {
            if (bag.MyBagScript.IsOpen != closedBag)
            {
                bag.MyBagScript.OpenClose();
            }
        }
    }
}
