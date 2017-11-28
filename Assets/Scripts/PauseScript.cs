using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseScript : MonoBehaviour {

    [SerializeField]
    private GameObject pausePanel;

    [SerializeField]
    private GameObject UIPanel;

    [SerializeField]
    private GameObject errorText;
    [SerializeField]
    private GameObject DevText;
    [SerializeField]
    private GameObject PowerUpMun;

    private bool isInPause = false;

    private GameManager gameManager;



	// Use this for initialization
	void Start () {
        gameManager = FindObjectOfType<GameManager>();
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetButton("Pause") && !isInPause)
        {
            isInPause = true;
            pausePanel.SetActive(true);
            UIPanel.SetActive(false);
            Time.timeScale = 0;
        }
	}

    public void ResumeGame()
    {
        isInPause = false;
        pausePanel.SetActive(false);
        UIPanel.SetActive(true);
        Time.timeScale = 1;
    }
    
    public void DebugThis()
    {
        errorText.SetActive(true);
        DevText.SetActive(true);
        PowerUpMun.SetActive(true);
    }

    public void BackToMainMenu()
    {
        Time.timeScale = 1;
        gameManager.MainMenu();
    }
}
