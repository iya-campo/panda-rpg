using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ObjectivesManager : MonoBehaviour {

    public string[] objectives;

    public int currentObjective;
    public Text objectiveText;
    private MainStory mainStory;

	// Use this for initialization
	void Start () {
        currentObjective = 0;
        mainStory = GetComponent<MainStory>();
    }
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            ObjectiveProgress(currentObjective);
        }
    }

    public void ObjectiveProgress(int objIndex)
    {
        switch (objIndex)
        {
            case 0:
                DisplayNextObjective(currentObjective);
                currentObjective++;
                break;
            case 1:
                Debug.Log("Fulfilled 1");
                DisplayNextObjective(currentObjective);
                currentObjective++;
                mainStory.objectiveItem[0].gameObject.SetActive(false);
                break;
            case 2:
                Debug.Log("Fulfilled 2");
                DisplayNextObjective(currentObjective);
                currentObjective++;
                mainStory.objectiveItem[1].gameObject.SetActive(false);
                break;
            case 3:
                Debug.Log("Fulfilled 3");
                DisplayNextObjective(currentObjective);
                currentObjective++;
                mainStory.objectiveItem[2].gameObject.SetActive(false);
                break;
            case 4:
                Debug.Log("Fulfilled 4");
                DisplayNextObjective(currentObjective);
                currentObjective++;
                mainStory.objectiveItem[3].gameObject.SetActive(false);
                break;
            case 5:
                Debug.Log("Fulfilled 5");
                DisplayNextObjective(currentObjective);
                currentObjective++;
                mainStory.objectiveItem[4].gameObject.SetActive(false);
                break;
            case 6:
                Debug.Log("Fulfilled 6");
                DisplayNextObjective(currentObjective);
                currentObjective++;
                mainStory.objectiveItem[5].gameObject.SetActive(false);
                break;
            case 7:
                Debug.Log("Fulfilled 7");
                DisplayNextObjective(currentObjective);
                currentObjective++;
                mainStory.objectiveItem[6].gameObject.SetActive(false);
                break;
            case 8:
                Debug.Log("Fulfilled 8");
                DisplayNextObjective(currentObjective);
                currentObjective++;
                mainStory.objectiveItem[7].gameObject.SetActive(false);
                break;
        }
    }


    public void DisplayNextObjective(int objIndex)
    {
        if (currentObjective < objectives.Length)
        {
            objectiveText.text = "[ ] " + objectives[currentObjective];
            mainStory.objectiveItem[objIndex].gameObject.SetActive(true);
        }
    }
}
