using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicSwitcher : MonoBehaviour {

    public int newTrack;
    public bool switchOnStart;

    private MusicController mController;

	// Use this for initialization
	void Start () {
        mController = FindObjectOfType<MusicController>();
        if (switchOnStart)
        {
            if (mController.currentTrack != newTrack)
            {
                mController.SwitchTrack(newTrack);
                gameObject.SetActive(false);
            }
        }
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.name == "Player")
        {
            mController.SwitchTrack(newTrack);
            gameObject.SetActive(false);
        }
    }
}
