using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void ExitGame()
    {
        Application.Quit();
    }
    
    public void MainMenu()
    {
        SceneManager.LoadScene("StartMenu");
    }

    public void LevelOne()
    {
        SceneManager.LoadScene("FirstLevel");
    }

    public void LevelTwo()
    {
        SceneManager.LoadScene("SecondLevel");
    }
}
