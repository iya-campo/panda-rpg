using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopScript : MonoBehaviour {

    private int itemPrice;

    private PlayerController thePlayer;
    private InventoryScript myInventory;
    private MoneyManager monManager;
    
    public CanvasGroup canvasGroup;
    public Text nameText;
    public Text priceText;
    public Text playerGold;

    // Use this for initialization
    void Start () {
        thePlayer = FindObjectOfType<PlayerController>();
        myInventory = FindObjectOfType<InventoryScript>();
        monManager = FindObjectOfType<MoneyManager>();
        OpenClose();
    }
	
	// Update is called once per frame
	void Update () {
        /*
		if (Input.GetKeyDown(KeyCode.N))
        {
            OpenClose();
        }
        */
        playerGold.text = "Your Gold: " + monManager.currentGold.ToString() + "g";
            
        //Item Name
        nameText.text = myInventory.items[1].name;
        //Item Price
        priceText.text = myInventory.items[1].MyItemPrice.ToString() + "g";
    }

    public void PurchaseItem(int itemIndex)
    {
        itemPrice = myInventory.items[itemIndex].MyItemPrice;

        if (monManager.currentGold >= itemPrice)
        {
            myInventory.PlaceItemInBag(itemIndex);
            monManager.LoseMoney(itemPrice);
        }
    }

    public void OpenClose()
    {
        canvasGroup.alpha = canvasGroup.alpha > 0 ? 0 : 1;
        canvasGroup.blocksRaycasts = canvasGroup.blocksRaycasts == true ? false : true;
        if (canvasGroup.alpha == 1)
        {
            thePlayer.canMove = false;
        }
        else
        {
            thePlayer.canMove = true;
        }
    }
}
