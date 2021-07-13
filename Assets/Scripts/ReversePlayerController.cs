using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReversePlayerController : MonoBehaviour
{
    [SerializeField] float speed;
    [SerializeField] float jumpPower;
    [SerializeField] float downPower;
    private Rigidbody playerRb;
    [SerializeField] float gravityModifier;
    public bool isOnGround = false;  //Karakter yerde mi
    public LevelLoader lvlLoaderScript;
    public Timer timer;
    public ParticleSystem explosionEffect;
    public ParticleSystem plasmaExplosionEffect;
    void FixedUpdate()
    {
        //Karakterin düşmesini engeller
        if (transform.position.z < 0 || transform.position.z > 0)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, 0);
        }
    }
    void Start()
    {
        Cursor.visible = false;
        playerRb = GetComponent<Rigidbody>();
        Physics.gravity *= gravityModifier;
    }

    // Update is called once per frame
    void Update()
    {

        Run();
        Jump();
        GameOver();
        Particles();
    }
    public void Run()
    {
        //Sağ ve sola ilerleme
        if (Input.GetKey(KeyCode.A))
        {
            transform.Translate(Vector3.forward * Time.deltaTime * speed);
            //gameObject.transform.eulerAngles = new Vector3(gameObject.transform.eulerAngles.x, 90, gameObject.transform.eulerAngles.z);
        }
        else if (Input.GetKey(KeyCode.D))
        {
            transform.Translate(-Vector3.forward * Time.deltaTime * speed);
            //gameObject.transform.eulerAngles = new Vector3(gameObject.transform.eulerAngles.x, 270, gameObject.transform.eulerAngles.z);
        }
    }
    public void Jump()
    {
        if (Input.GetKey(KeyCode.S) && isOnGround)
        {
            playerRb.AddForce(Vector3.up * jumpPower, ForceMode.Impulse);
            isOnGround = false;
        }

        if (Input.GetKey(KeyCode.W) && !isOnGround)
        {
            playerRb.AddForce(Vector3.down * downPower, ForceMode.Impulse);
        }
        //isIdle = true;
    }

    public void GameOver()
    {
        if (transform.position.y < -6)
        {
            transform.position = new Vector3(-9, -3.5f, 0);
        }
        else if(timer.currentTime <= 1)
        {
            transform.position = new Vector3(-9, -3.5f, 0);
        }
    }
    public void Particles()
    {
        if(timer.currentTimeInt == 40)
        {
            explosionEffect.Play();
        }
        if(timer.currentTime == 38)
        {
            plasmaExplosionEffect.Play();
        }
        
    }
    private void OnCollisionEnter(Collision collision)
    {
        isOnGround = true;
        //To End Scene
        if (collision.gameObject.CompareTag("Door"))
        {
            lvlLoaderScript.LoadNextLevel();
        }
    }
}
