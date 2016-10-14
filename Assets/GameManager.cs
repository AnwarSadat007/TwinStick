using UnityEngine;
using System.Collections;
using UnityStandardAssets.CrossPlatformInput;
using System;

public class GameManager : MonoBehaviour {

    public bool recording = false;
    private float fixedDeltaTime;
    private bool isPaused = false;

	// Use this for initialization
	void Start () {
        fixedDeltaTime = Time.fixedDeltaTime;
	}
	
	// Update is called once per frame
	void Update () {

        recording = !CrossPlatformInputManager.GetButton("Fire1");

        if (Input.GetKeyDown(KeyCode.P) && isPaused)
        {
            isPaused = false;
            ResumeGame();
        } else if (Input.GetKeyDown(KeyCode.P) && !isPaused)
        {
            isPaused = true;
            PauseGame();
        }


    }

    void PauseGame()
    {
        Time.timeScale = 0;
        Time.fixedDeltaTime = 0;
    }

    void ResumeGame()
    {
        Time.timeScale = 1.0f;
        Time.fixedDeltaTime = fixedDeltaTime;

    }

    void OnApplicationPause (bool pauseStatus)
    {
        isPaused = pauseStatus;
    }
}
