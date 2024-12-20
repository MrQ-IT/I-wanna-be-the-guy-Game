using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D playerRb;
    private Animator playerAnim;
    private float speed;
    private bool isGrounded;
    private int indexJump;
    private float jumpForce;
    private bool isMove;
    private bool checkDie;
    private AudioSource audioSource;
    [SerializeField] private AudioClip appearing;
    [SerializeField] private AudioClip desappearing;
    [SerializeField] private AudioClip run;
    [SerializeField] private AudioClip jump;
    [SerializeField] private AudioClip death;

    void Start()
    {
        Initialize();
    }

    void Update()
    {
        Jumping();
        Moving();
        ResetGame();
    }

    private void Initialize()
    {
        speed = 7f;
        jumpForce = 16;
        playerRb = GetComponent<Rigidbody2D>();
        playerAnim = GetComponent<Animator>();
        audioSource = GetComponent<AudioSource>();
        isGrounded = true;
        isMove = false;
        checkDie = false;
        SetAndPlaySound(appearing);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.name == "OutFlag" && !checkDie)
        {
            Debug.Log(checkDie);
            NextMap();
        }
        else if (collision.transform.CompareTag("Ground"))
        {
            ConditionsJumping();
        }
        else if (collision.transform.CompareTag("MovingPlatform"))
        {
            transform.SetParent(collision.transform);
            ConditionsJumping();
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.transform.CompareTag("MovingPlatform") && !checkDie && collision.gameObject.activeInHierarchy)
        {
            transform.parent = null;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.CompareTag("Traps") && !checkDie)
        {
            audioSource.clip = null;
            SetAndPlaySound(death);
            audioSource.loop = false;
            playerAnim.SetBool("Hit", true);
            transform.GetChild(0).gameObject.SetActive(true);
            isMove = false;
            checkDie = true;
        }
    }

    // Animation Event 
    private void TurnOffHitAnim()
    {
        playerAnim.SetBool("Hit", false);
        transform.GetChild(0).gameObject.SetActive(false);
        CanvasManager.instance.returnImage.SetActive(true);
    }

    // Animation Event
    private void EndAppearing()
    {
        isMove = true;
        audioSource.Stop();
    }

    private void NextMap()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        if (currentSceneIndex == 6)
        {
            CanvasManager.instance.GameWin();
            Time.timeScale = 0;
        }
        else
            SceneManager.LoadScene(currentSceneIndex + 1);
    }

    private void Moving()
    {
        if (isMove && !checkDie)
        {
            // move horizontal
            float xInput = Input.GetAxisRaw("Horizontal");
            playerRb.velocity = new Vector2(xInput * speed, playerRb.velocity.y);

            // set animation parameter
            if (xInput != 0)
            {
                playerAnim.SetBool("Idle", false);
                SetAndPlaySound(run);
            }
            else
            {
                playerAnim.SetBool("Idle", true);
                audioSource.clip = null;
            }

            //flip player when move left - right
            if (xInput > 0.01f)
            {
                transform.localScale = new Vector3(1, 1, 1);
            }
            else if (xInput < -0.01f)
            {
                transform.localScale = new Vector3(-1, 1, 1);
            }
        }
        else
        {
            playerAnim.SetBool("Idle", true);
        }
    }

    private void Jumping()
    {
        // jumping
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded && isMove)
        {
            playerRb.velocity = new Vector2(playerRb.velocity.x, jumpForce);
            indexJump += 1;
            playerAnim.SetBool("Jump", true);
            if (indexJump == 2)
            {
                isGrounded = false;
                playerAnim.SetBool("Jump", false);
                playerAnim.SetBool("Fall", true);
            }

        }
    }

    private void ConditionsJumping()
    {
        isGrounded = true;
        playerAnim.SetBool("Fall", false);
        playerAnim.SetBool("Jump", false);
        indexJump = 0;
    }

    private void ResetGame()
    {
        if (checkDie && Input.GetKeyDown(KeyCode.R))
        {
            GameObject.Find("Main Camera").GetComponent<GameManager>().ResetGame();
            CanvasManager.instance.returnImage.SetActive(false);
        }
    }

    public void SetAndPlaySound(AudioClip audio)
    {
        if (audioSource.clip == null)
        {
            audioSource.clip = audio;
            audioSource.Play();
        }
    }
}
