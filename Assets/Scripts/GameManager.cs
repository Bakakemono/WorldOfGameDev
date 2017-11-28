using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {
    private bool ActivateFinalBoss = false;
    public static int PlayerPV = 20;
    public static int Mun = 20;
    private bool PowerUpisActif = false;
    private int loading = 0;


    // Use this for initialization
    void Start () {
        DontDestroyOnLoad(gameObject);
	}
	
	// Update is called once per frame
	void Update () {
        if (PlayerPV <= 0)
        {
            Defeat();
            PlayerPV = 1;
        }
        if (PowerUpisActif)
            loading++;


        if (loading >= 100)
        {
            Mun++;
            loading = 0;
            if (Mun >= 30)
                Mun = 30;
        }
            
       
	}
    public void TakePowerUp()
    {
        PowerUpisActif = true;
    }

    public void TakeDamage()
    {
        
        PlayerPV--;
    }
    
    public void ExitGame()
    {
        Application.Quit();
    }
    
    public void MainMenu()
    {
        PlayerPV = 20;
        Mun = 20;
        PowerUpisActif = false;
        loading = 0;
        SceneManager.LoadScene("StartMenu");
        
    }

    public void LevelOne()
    {
        PlayerPV = 20;
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
 
    }

    public void Defeat()
    {
        SceneManager.LoadScene("DeathMenu");
     
    }

    public void Win()
    {
        SceneManager.LoadScene("WinMenu");

    }
}
