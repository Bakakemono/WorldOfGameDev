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
    
    private GameManager gameManager;
    [SerializeField]
    private GameObject PowerUp;
    
    
    // Use this for initialization
    void Start()
    {
        rigid = GetComponent<Rigidbody2D>();
        spawnTranform = GameObject.Find("Spawn").transform;
        
        BossScript = FindObjectOfType<BossScript>();
        gameManager = FindObjectOfType<GameManager>();

        playerAnimationControle = GetComponent<Animator>();
        render = GetComponent<SpriteRenderer>();
    }
    

    // Update is called once per frame
    void Update()
    {
        
        horizontalInput = Input.GetAxis("Horizontal");
        render.flipX = horizontalInput < 0;
        playerAnimationControle.SetFloat("SpeedX", Mathf.Abs(horizontalInput));
        horizontalInput *= Force;
        rigid.velocity = new Vector2(horizontalInput, rigid.velocity.y);

        FlipWeapon = GameObject.Find("FlipWeapon").transform;

        if (horizontalInput < -0.1 && isRotate == false)
        {
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

        if (Input.GetAxis("Fire2") > 0 )
        {
            playerAnimationControle.SetBool("Throw",true);
            
        }
        
    }

    private void StopThrow()
    {
        playerAnimationControle.SetBool("Throw", false);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Lava")
        {
            GameManager.PlayerPV--;
            transform.position = spawnTranform.position;
        }

        if (collision.tag == "Limit")
        {
            GameManager.PlayerPV--;
            transform.position = spawnTranform.position;
        }
        if (collision.tag == "BeginTheRealGame")
        {
            BossScript.ShootTheDev();
        }
        if(collision.tag == "ToLevelTwo")
        {
            gameManager.LevelTwo();
        }
        if (collision.tag == "ToLevelThree")
        {
            gameManager.LevelThree();
        }
        if (collision.tag == "ToTheBoss")
        {
            gameManager.BossLevel();
        }

        if (collision.tag == "EnemiBullet")
        {
            gameManager.TakeDamage();
        }
        if (collision.tag == "PowerUp")
        {
            gameManager.TakePowerUp();
            Destroy(PowerUp);
        }
    }

   


    private void Fire()
    {
        if (Time.realtimeSinceStartup - lastTimeFire > timeToFire && GameManager.Mun > 0)
        {
            Vector3 positionDebugEnd = gunTransform.position + gunTransform.right;
            Debug.DrawLine(gunTransform.position, positionDebugEnd, Color.red, 5);
            GameObject Bullet = Instantiate(bulletPrefab, gunTransform.position, gunTransform.rotation);
            Bullet.GetComponent<Rigidbody2D>().velocity = gunTransform.right * bulletVelocity;
            Destroy(Bullet, 5);
            lastTimeFire = Time.realtimeSinceStartup;
            GameManager.Mun--;
        }
    }
}
