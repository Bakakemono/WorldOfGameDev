using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HudManager : MonoBehaviour {

    [SerializeField]
    private Text textLife;
    [SerializeField]
    private Text textMun;

    
    private const string TEXT_LIFES = "Lifes : ";
    private const string TEXT_MUN = "Key Mun : ";


    // Use this for initialization
    void Start () {
        
	}
	
	// Update is called once per frame
	void Update () {
        textLife.text = TEXT_LIFES + GameManager.PlayerPV;
        textMun.text = TEXT_MUN + GameManager.Mun;
        

	}
}
