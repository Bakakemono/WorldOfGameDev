using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletPlayerManager : MonoBehaviour {

    [SerializeField]
    private MultiSoundRandom BreakSound;
    
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Enemi")
        {
            BreakSound.PlaySound();
            Destroy(gameObject);
        }
        if (collision.gameObject.tag == "Platform")
        {
            BreakSound.PlaySound();
            Destroy(gameObject);
        }
        if(collision.gameObject.tag == "Boss")
        {
            BreakSound.PlaySound();
            Destroy(gameObject);
        }
        

    }
    
}
