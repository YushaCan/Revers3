using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    [SerializeField] float speed;
    [SerializeField] float jumpPower;
    [SerializeField] float downPower;
    [SerializeField] int pickedCoins;
    public bool isRunning = false;
    private Rigidbody playerRb;
    public Animator playerAnim;
    private AudioSource playerAudio;
    public AudioClip jumpSound;
    public AudioClip runSound;
    public AudioClip coinSound;
    [SerializeField] float gravityModifier;
    public bool isOnGround = false;  //Karakter yerde mi
    public LevelLoader lvlLoaderScript;

    void FixedUpdate()
    {
        //Karakterin düşmesini engeller
        if(transform.position.z < 8.5f || transform.position.z > 8.5f)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, 8.5f);
        }
    }
    void Start()
    {
        Cursor.visible = false;
        playerAudio = GetComponent<AudioSource>();
        playerRb = GetComponent<Rigidbody>();
        Physics.gravity *= gravityModifier;
    }

    // Update is called once per frame
    void Update()
    {
        float x = Input.GetAxis("Horizontal");
        if (x == 0)
        {
            playerAnim.SetBool("Run", false);
        }
        Run();
        Jump(); 
        GameOver();

        
    }
    public void Run()
    {      
        //Sağ ve sola ilerleme
        if (Input.GetKey(KeyCode.D))
        {
            isRunning = true;
            playerAnim.SetBool("Run", true);
            transform.Translate(Vector3.forward * Time.deltaTime * speed );
            gameObject.transform.eulerAngles = new Vector3(gameObject.transform.eulerAngles.x, 90, gameObject.transform.eulerAngles.z);
        }
        else if (Input.GetKey(KeyCode.A))
        {
            isRunning = true;
            playerAnim.SetBool("Run", true);
            transform.Translate(Vector3.forward * Time.deltaTime * speed);
            gameObject.transform.eulerAngles  = new Vector3(gameObject.transform.eulerAngles.x ,270 , gameObject.transform.eulerAngles.z);
        }
    }
    public void Jump()
    {
        if (Input.GetKey(KeyCode.W) && isOnGround)
        {
            playerAudio.PlayOneShot(jumpSound);
            playerRb.AddForce(Vector3.up * jumpPower, ForceMode.Impulse);
            isOnGround = false;
        }

        if (Input.GetKey(KeyCode.S) && !isOnGround)
        {
            playerRb.AddForce(Vector3.down * downPower, ForceMode.Impulse);
        }
    }

    public void GameOver()
    {
        if (transform.position.y < -6)
        {
            transform.position = new Vector3(-15, 5.44f, 8.5f);
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        isOnGround = true;
        //Next Level
        if (collision.gameObject.CompareTag("Door") && pickedCoins >= 8)
        {
            lvlLoaderScript.LoadNextLevel();
        }
        if (collision.gameObject.CompareTag("Coin"))
        {
            playerAudio.PlayOneShot(coinSound);
            pickedCoins++;
        }
    }
}
