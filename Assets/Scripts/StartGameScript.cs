using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartGameScript : MonoBehaviour {

    [SerializeField]
    GameManager gameManager;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void RunGame()
    {
        gameManager.LevelOne();
    }
    public void Credit()
    {
        gameManager.Credit();
    }
    public void Exit()
    {
        Debug.Log("Exit");
        gameManager.ExitGame();
    }
}
