using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemiControler : MonoBehaviour {

    [SerializeField]
    private GameObject bulletPrefab;
    [SerializeField]
    private Transform gunTransform;
    [SerializeField]
    private float bulletVelocity;
    [SerializeField]
    private float timeToFire;




    // Use this for initialization
    void Start () {
        StartCoroutine(Fire());
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private IEnumerator Fire()
    {
        while (true)
        {
            yield return new WaitForSeconds(timeToFire);
            //foreach (Transform t in gunsTransformList)
            {
                GameObject bullet = Instantiate(bulletPrefab, gunTransform.position, gunTransform.rotation);
                bullet.GetComponent<Rigidbody2D>().velocity = gunTransform.right * bulletVelocity;
                Destroy(bullet, 5);
            }
        }
    }
}
