using UnityEngine;

public class EnemiManager: MonoBehaviour {

    [Header("Life")]
    [SerializeField]
    private int PV = 4;

    [Header("Gun")]
    [SerializeField]
    private GameObject bulletPrefab;
    [SerializeField]
    private Transform[] gunsTransformList;
    [SerializeField]
    private float bulletVelocity;

    public bool Attack;

    [SerializeField]
    private MultiSoundRandom bulletSound;
    
    
    
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
        
        if (PV<=0)
        {
            Destroy(gameObject);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "PlayerBullet")
        {
            if (Attack == true)
            {
                EnemiAnimatorControler.SetBool("Attacking", false);
            }
            EnemiAnimatorControler.SetBool("TakeDamage", true);
            PV--;
        }
      
    }
    private void HadTakedamage()
    {
        if(Attack == true)
        {
            EnemiAnimatorControler.SetBool("Attacking", true);
        }
        EnemiAnimatorControler.SetBool("TakeDamage", false);
    }
    
    private void Fire()
    {
        foreach (Transform t in gunsTransformList)
        {
            GameObject bullet = Instantiate(bulletPrefab, t.position, t.rotation);
            bullet.GetComponent<Rigidbody2D>().velocity = t.right * bulletVelocity;
            Destroy(bullet, 5);
        }
        bulletSound.PlaySound();
    }

    
}
