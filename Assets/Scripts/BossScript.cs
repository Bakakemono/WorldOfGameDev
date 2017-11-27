using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossScript : MonoBehaviour {

    [SerializeField]
    private GameObject bulletPrefab;
    [SerializeField]
    private Transform gunTransform;
    [SerializeField]
    private float bulletVelocity = 13;
    [SerializeField]
    private GameObject player;
    [SerializeField]
    private Transform[] spawnPoints;
    private int Index;

    private Animator BossAnimationControler;


    // Use this for initialization
    void Start() {
        BossAnimationControler = GetComponent<Animator>();

    }

    // Update is called once per frame
    void Update() {
        if (player != null)
            gunTransform.LookAt(player.transform);
    }

    public void ShootTheDev()
    {
        BossAnimationControler.SetBool("ShootTheDev", true);

    }

    public void StopShooting()
    {
        BossAnimationControler.SetBool("ShootTheDev", false);
    }

    private void Fire()
    {
        GameObject Bullet = Instantiate(bulletPrefab, gunTransform.position, gameObject.transform.rotation);

        if (player != null)
        {
            Bullet.GetComponent<Rigidbody2D>().velocity = gunTransform.forward* bulletVelocity;
        }
        else
        {
            Bullet.GetComponent<Rigidbody2D>().velocity = gunTransform.right * bulletVelocity;
        }
        Destroy(Bullet, 3);
    }
}
