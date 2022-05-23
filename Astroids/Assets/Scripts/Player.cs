using UnityEngine;

public class Player : MonoBehaviour
{
    #region Variables
    public Bullet bulletPrefab;

   // public GameManager gameManager;

    public float thrustSpeed = 1.0f;
    public float turnSpeed = 1.0f;

    private Rigidbody2D rigidbody2d;

    public AudioSource audioSource; 
    public AudioClip playerDeath, shoot, hitAsteroyd; 

    private bool _thrusting;
    public bool shouldShoot = true;

    private float _turnDirection;
    #endregion

    private void Awake()
    {
        rigidbody2d = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        //Checking and implementing input controlls for Player
        _thrusting = Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow);

        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {
            _turnDirection = 1.0f;
        } else if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow)){
            _turnDirection = -1.0f;
        } else
        {
            _turnDirection = 0.0f;
        }

        if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0))
        {
            Shoot();    
        }

    }

    private void FixedUpdate()
    {
        //Handeling movement and rotation
        if (_thrusting)
        {
            rigidbody2d.AddForce(this.transform.up * this.thrustSpeed);
        }
        if (_turnDirection != 0.0f)
        {
            rigidbody2d.AddTorque(_turnDirection * this.turnSpeed); 
        }
    }

    private void Shoot()
    {
        if (shouldShoot)
        {
            Bullet bullet = Instantiate(this.bulletPrefab, this.transform.position, this.transform.rotation);
            bullet.Project(this.transform.up);

            this.audioSource.PlayOneShot(shoot);
        }
    }

    private void PlayerDeath()
    {
        rigidbody2d.velocity = Vector3.zero;
        rigidbody2d.angularVelocity = 0.0f;

        this.audioSource.PlayOneShot(playerDeath);

        this.gameObject.SetActive(false);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Asteroid"))
        {
            PlayerDeath();
        }

        FindObjectOfType<GameManager>().PlayerDied();
    }

}
