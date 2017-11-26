using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerControler : MonoBehaviour
{

    [Header("Physics")]
    [SerializeField]
    private float Force = 10;
    private Rigidbody2D rigid;
    private float horizontalInput;

    [Header("Jump")]
    [SerializeField]
    private Transform positionRaycastJump;
    [SerializeField]
    private Vector2 sizeRaycastJump;
    [SerializeField]
    private float radiusRaycastJump;
    [SerializeField]
    private LayerMask layerMaskJump;
    [SerializeField]
    private float forceJump = 5;

    [Header("MachineGun")]
    [SerializeField]
    private GameObject bulletPrefab;
    [SerializeField]
    private Transform gunTransform;
    [SerializeField]
    private float bulletVelocity = 2;
    [SerializeField]
    private float timeToFire = 2;
    private float lastTimeFire = 0;

    private Transform spawnTranform;

    private Animator playerAnimationControle;
    private SpriteRenderer render;

    [SerializeField]
    private Transform FlipWeapon;
    private bool isRotate;
    

    private BossScript BossScript;
    [SerializeField] GameManager gameManager;

    
    // Use this for initialization
    void Start()
    {
        rigid = GetComponent<Rigidbody2D>();
        spawnTranform = GameObject.Find("Spawn").transform;
        
        BossScript = FindObjectOfType<BossScript>();
        //gameManager = FindObjectOfType<GameManager>();

        playerAnimationControle = GetComponent<Animator>();
        render = GetComponent<SpriteRenderer>();
    }
    

    // Update is called once per frame
    void Update()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        render.flipX = horizontalInput < 0;
        playerAnimationControle.SetFloat("SpeedX", Mathf.Abs(horizontalInput));
        Vector2 forceDirection = new Vector2(horizontalInput, 0);
        horizontalInput *= Force;
        rigid.velocity = new Vector2(horizontalInput, rigid.velocity.y);


        FlipWeapon = GameObject.Find("FlipWeapon").transform;

        if (horizontalInput < -0.1 && isRotate == false)
        {
            Debug.Log("Should Flip");
            FlipWeapon.Rotate(0, 180, 0);
            isRotate = true;
        }
        else if (horizontalInput > -0.1 && isRotate == true)
        {
            FlipWeapon.Rotate(0, 180, 0);
            isRotate = false;
        }
        

        bool touchFloor = Physics2D.OverlapBox(positionRaycastJump.position, sizeRaycastJump, 0, layerMaskJump);
        if (Input.GetKeyDown("space") && touchFloor)
        {

            rigid.AddForce(Vector2.up * forceJump, ForceMode2D.Impulse);
        }

        if (Input.GetAxis("Fire2") > 0)
        {
            Fire();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Lava")
        {
            transform.position = spawnTranform.position;
        }

        if (collision.tag == "Limit")
        {
            transform.position = spawnTranform.position;
        }
        if (collision.tag == "BeginTheRealGame")
        {
            BossScript.ShootTheDev();
        }
        if(collision.tag == "OverpoweredBullet")
        {
            gameManager.LevelTwo();
        }
    }
    

    private void Fire()
    {
        if (Time.realtimeSinceStartup - lastTimeFire > timeToFire)
        {
            Vector3 positionDebugEnd = gunTransform.position + gunTransform.right;
            Debug.DrawLine(gunTransform.position, positionDebugEnd, Color.red, 5);
            GameObject Bullet = Instantiate(bulletPrefab, gunTransform.position, gunTransform.rotation);
            Bullet.GetComponent<Rigidbody2D>().velocity = gunTransform.right * bulletVelocity;
            Destroy(Bullet, 5);
            lastTimeFire = Time.realtimeSinceStartup;
        }
    }
}
