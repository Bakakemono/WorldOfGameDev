using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseScript : MonoBehaviour {

    [SerializeField]
    private GameObject pausePanel;

    [SerializeField]
    private GameObject errorText;

    private bool isInPause = false;

    [SerializeField]
    private GameManager gameManager;



	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetButton("Pause") && !isInPause)
        {
            isInPause = true;
            pausePanel.SetActive(true);
            Time.timeScale = 0;
        }
	}

    public void ResumeGame()
    {
        isInPause = false;
        pausePanel.SetActive(false);
        Time.timeScale = 1;
    }
    
    public void DebugThis()
    {
        errorText.SetActive(true);
    }

    public void BackToMainMenu()
    {
        Time.timeScale = 1;
        gameManager.MainMenu();
    }
}
