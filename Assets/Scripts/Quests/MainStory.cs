using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainStory : MonoBehaviour {

    //Objective 1
    public bool IsInHouse;

    //Objective 2
    public bool BonesComplete, BeefComplete, EntrailsComplete;

    //Objective 3
    public bool IsInOlympus;

    //Objective 4
    public bool BossKilled;

    public ObjectivesItem[] objectiveItem;

    private InventoryScript inventoryScript;

    private ObjectivesManager objectivesManager;
    private ObjectiveTrigger1 objTrig1;
    private ObjectiveTrigger2 objTrig2;
    private ObjectiveTrigger3 objTrig3;
    private ObjectiveTrigger4 objTrig4;

    // Use this for initialization
    void Start () {
        inventoryScript = FindObjectOfType<InventoryScript>();
        objectivesManager = FindObjectOfType<ObjectivesManager>();
        objTrig1 = FindObjectOfType<ObjectiveTrigger1>();
        objTrig2 = FindObjectOfType<ObjectiveTrigger2>();
        objTrig3 = FindObjectOfType<ObjectiveTrigger3>();
        objTrig4 = FindObjectOfType<ObjectiveTrigger4>();
    }
	
	// Update is called once per frame
	void Update () {
        ObjectiveCompletion();
    }
    
    public void ObjectiveCompletion()
    {
        if (objectiveItem[0].gameObject.activeInHierarchy)
        {
            if (IsInHouse)
            {
                objectivesManager.ObjectiveProgress(objectivesManager.currentObjective);
            }
        }
        if (objectiveItem[1].gameObject.activeInHierarchy)
        {
            if (BonesComplete && BeefComplete && EntrailsComplete)
            {
                inventoryScript.InstantiateCrates();
                inventoryScript.CompleteLoot = true;
                objectivesManager.ObjectiveProgress(objectivesManager.currentObjective);
            }
        }
        if (objectiveItem[2].gameObject.activeInHierarchy)
        {
            if (IsInOlympus)
            {
                objectivesManager.ObjectiveProgress(objectivesManager.currentObjective);
            }
        }
        if (objectiveItem[3].gameObject.activeInHierarchy)
        {
            if (BossKilled)
            {
                objectivesManager.ObjectiveProgress(objectivesManager.currentObjective);
            }
        }
        /*
        if (objectiveItem[4].gameObject.activeInHierarchy)
        {
            if (IsInHouse)
            {
                objectivesManager.ObjectiveProgress(objectivesManager.currentObjective);
            }
        }
        if (objectiveItem[5].gameObject.activeInHierarchy)
        {
            if (IsInHouse)
            {
                objectivesManager.ObjectiveProgress(objectivesManager.currentObjective);
            }
        }
        if (objectiveItem[6].gameObject.activeInHierarchy)
        {
            if (IsInHouse)
            {
                objectivesManager.ObjectiveProgress(objectivesManager.currentObjective);
            }
        }
        if (objectiveItem[7].gameObject.activeInHierarchy)
        {
            if (IsInHouse)
            {
                objectivesManager.ObjectiveProgress(objectivesManager.currentObjective);
            }
        }
        */
    }
}
