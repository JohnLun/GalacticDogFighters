using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Player2 : MonoBehaviour
{
    public int maxHealth = 5;
    public int currentHealth;
    public HealthBar healthBar;
    public new Rigidbody2D rigidbody { get; private set; }

    public float thrustSpeed = 1f;
    public bool thrusting { get; private set; }

    public float turnDirection { get; private set; } = 0f;
    public float rotationSpeed = 0.1f;

    public Bullet bulletPrefab;
    public P2HomingMissile hmPrefab;

    public bool regShot;
    public bool hmShot;

    private int counter;

    private void Start()
    {
        regShot = true;
        hmShot = false;
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
    }
    private void Awake()
    {
        rigidbody = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        thrusting = Input.GetKey(KeyCode.UpArrow);

        if (Input.GetKey(KeyCode.LeftArrow))
        {
            turnDirection = 1f;
        }
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            turnDirection = -1f;
        }
        else
        {
            turnDirection = 0f;
        }

        if (Input.GetKeyDown(KeyCode.RightShift))
        {
            if(regShot)
            {
                Shoot();
                SoundManager.PlaySound("bullet");
            }
            else if(hmShot)
            {
                ShootHomingMissile();
                SoundManager.PlaySound("missile");
                counter++;
                if(counter == 5)
                {
                    regShot = true;
                    hmShot = false;
                    counter = 0;
                }
            }
        }
    }

    private void FixedUpdate()
    {
        if (thrusting)
        {
            rigidbody.AddForce(transform.up * thrustSpeed);
        }

        if (turnDirection != 0f)
        {
            rigidbody.AddTorque(rotationSpeed * turnDirection);
        }
    }

    private void ShootHomingMissile()
    {
        P2HomingMissile hm = Instantiate(hmPrefab, transform.position, transform.rotation);
    }

    private void Shoot()
    {
        Bullet bullet = Instantiate(bulletPrefab, transform.position, transform.rotation);
        bullet.Project(transform.up);
    }

    private void TurnOnCollisions()
    {
        gameObject.layer = LayerMask.NameToLayer("Player2");
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("P1Bullet"))
        {
            currentHealth -= 1;
            healthBar.SetHealth(currentHealth);
            SoundManager.PlaySound("hit");
        }
        if (collision.gameObject.CompareTag("HomingMissile"))
        {
            Debug.Log("HIT");
            currentHealth -= 1;
            healthBar.SetHealth(currentHealth);
            SoundManager.PlaySound("hit");
        }
        if (collision.gameObject.CompareTag("Asteroid"))
        {
            rigidbody.velocity = Vector3.zero;
            rigidbody.angularVelocity = 0f;

        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        int powerUp = Random.Range(1, 3);
        if (collision.CompareTag("Crate"))
        {
            if (powerUp == 1)
            {
                regShot = true;
                hmShot = false;
            }
            else if (powerUp == 2)
            {
                regShot = false;
                hmShot = true;
            }
        }
    }

}