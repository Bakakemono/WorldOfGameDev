using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemiControler : MonoBehaviour {

    [SerializeField]
    private GameObject bulletPrefab;
    [SerializeField]
    private Transform[] gunsTransformList;
    [SerializeField]
    private float bulletVelocity;

    public bool Attack;
    private Animator EnemiAnimatorControler;
    




    // Use this for initialization
    void Start () {
        EnemiAnimatorControler = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
        if (Attack == true)
        {
            EnemiAnimatorControler.SetBool("Attacking", true);
            
        }
        if (Attack == false)
        {
            EnemiAnimatorControler.SetBool("Attacking", false);
        }

    }
    private void Fire()
    {
        foreach (Transform t in gunsTransformList)
        {
            GameObject bullet = Instantiate(bulletPrefab, t.position, t.rotation);
            bullet.GetComponent<Rigidbody2D>().velocity = t.right * bulletVelocity;
            Destroy(bullet, 5);
        }
    }

    
}
