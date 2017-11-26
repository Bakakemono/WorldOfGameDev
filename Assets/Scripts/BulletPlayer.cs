using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletPlayer : MonoBehaviour {

    [SerializeField]
    private GameObject bulletPrefab;
    
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Platform" || collision.tag == "Enemi")
        {
            Destroy(bulletPrefab);
        }
        
    }
}
