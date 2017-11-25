using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossScript : MonoBehaviour {

    [SerializeField]
    private GameObject bulletPrefab;
    [SerializeField]
    private Transform gunTransform;
    [SerializeField]
    private float bulletVelocity = 2;
    [SerializeField]
    private float timeToFire = 2;
    private float lastTimeFire = 0;
    private bool hadShoot = false;


    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

    }

    public void ShootTheDev()
    {
        if (hadShoot == false)
        {
            Fire();
            hadShoot = true;
        }
    }

private void Fire()
    {
        Vector3 positionDebugEnd = gunTransform.position + gunTransform.right;
        //Debug.DrawLine(gunTransform.position, positionDebugEnd, Color.red, 5);
        GameObject Bullet = Instantiate(bulletPrefab, gunTransform.position, gunTransform.rotation);
        Bullet.GetComponent<Rigidbody2D>().velocity = gunTransform.right * bulletVelocity;
    }
}
