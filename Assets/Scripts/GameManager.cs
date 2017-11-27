using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {
    private bool ActivateFinalBoss = false;

	// Use this for initialization
	void Start () {
        DontDestroyOnLoad(gameObject);
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

    public void LevelThree()
    {
        SceneManager.LoadScene("ThirdLevel");
    }

    public void BossLevel()
    {
        SceneManager.LoadScene("BossLevel");
        ActivateFinalBoss = true;
    }
}
