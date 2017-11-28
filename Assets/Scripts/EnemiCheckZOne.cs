using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemiCheckZOne : MonoBehaviour {

    private EnemiManager enemiManager;
	// Use this for initialization
	void Start () {
        enemiManager = GetComponentInParent<EnemiManager>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            enemiManager.Attack = true;
            
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            enemiManager.Attack = false;
        }
    }

}
