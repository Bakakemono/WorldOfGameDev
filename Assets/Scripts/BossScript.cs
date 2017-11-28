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
    private int PV = 30;
    
    private GameManager gameManager;
    [SerializeField]
    private MultiSoundRandom bulletSound;


    // Use this for initialization
    void Start() {
        BossAnimationControler = GetComponent<Animator>();
        gameManager = FindObjectOfType<GameManager>();

    }

    // Update is called once per frame
    void Update() {
        if (player != null)
        {
            gunTransform.LookAt(player.transform);
        }
        if (player != null)
        {
            if (PV <= 20)
            {
                transform.position = spawnPoints[0].position;
               
            }
            if (PV <= 10)
            {
                transform.position = spawnPoints[1].position;

            }
            if (PV <=0)
            {
                gameManager.Win();
            }
        }

        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "PlayerBullet")
        {
            PV--;
        }
    }

    public void ShootTheDev()
    {
        BossAnimationControler.SetBool("ShootTheDev", true);

    }
    

    public void StopShooting()
    {
        if(player==null)
        {
            BossAnimationControler.SetBool("ShootTheDev", false);
        }
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
        bulletSound.PlaySound();
    }
}
