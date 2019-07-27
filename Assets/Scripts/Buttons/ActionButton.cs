using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ActionButton : MonoBehaviour, IPointerClickHandler {

    private IUseable useable;
    public Button MyButton { get; private set; }

    public Image Icon
    {
        get
        {
            return icon;
        }

        set
        {
            icon = value;
        }
    }

    [SerializeField]
    private Image icon;

    // Use this for initialization
    void Start () {
        MyButton = GetComponent<Button>();
        MyButton.onClick.AddListener(OnClick);
	}
	
	// Update is called once per frame
	void Update () {

    }

    public void OnClick()
    {
        if (useable != null)
        {
            useable.Use();
        }
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        
    }
}
