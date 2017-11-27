using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemiCheckZOne : MonoBehaviour {

    private EnemiControler enemiControler;
	// Use this for initialization
	void Start () {
        enemiControler = GetComponentInParent<EnemiControler>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            enemiControler.Attack = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            enemiControler.Attack = false;
        }
    }

}
