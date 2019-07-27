using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class ButtonTrigger : MonoBehaviour {

	public void StartGame()
    {
        SceneManager.LoadScene("Intro", LoadSceneMode.Single);
    }

    public void Tutorials()
    {
        SceneManager.LoadScene("controls", LoadSceneMode.Single);
    }

    public void EndDialogue()
    {
        SceneManager.LoadScene("innflr2", LoadSceneMode.Single);
    }
}
