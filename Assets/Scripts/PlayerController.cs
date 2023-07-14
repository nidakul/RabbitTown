using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;
using static UnityEngine.GraphicsBuffer;


public class PlayerController : MonoBehaviour     
{
    Rigidbody2D rb2d;
    Animator anim;

    //private GameObject player;
    public float runSpeed;
    private int jumpCount = 0;
    private bool canJump = true;

    public bool isGameOver = false; 
    public GameObject GameOverPanel, scoreText; 
    public Text FinalScoreText, HighScoreText;

    public float animSpeed;

    private int score; 
    public Text carrot;

    public float normalGravityScale = 1f; 
    public float fallGravityScale = 5f; 
    private bool isFalling = false;

    private Touch touch;

    // Start is called before the first frame update 
    void Start()
    {
        //anim.SetFloat("animSpeed", 3f);
        rb2d = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();

        StartCoroutine("IncreaseGameSpeed");

        rb2d.gravityScale = normalGravityScale;

    }

    // Update is called once per frame
    void Update()
    {

        if (!isGameOver) 
        {
            transform.position = Vector3.right * runSpeed * Time.deltaTime + transform.position;
        }
        

        if (jumpCount == 2)
        { 
            canJump = false; 
        }

        if (Input.GetKeyDown("space") && canJump && !isGameOver)
        {
            /*
            rb2d.velocity = Vector3.up * 7.5f;
            anim.SetTrigger("jump"); 
            jumpCount += 1;*/
            JumpButton();

           
        }

        //fall by increasing gravity
        if (Input.GetKey(KeyCode.DownArrow))
        {
            isFalling = true;
            rb2d.gravityScale = fallGravityScale; 
        }
        else if (isFalling) 
        {
            isFalling = false;
            rb2d.gravityScale = normalGravityScale;
        }

        if(Input.touchCount > 0)
        {
            SwipeDown();
        }



        if (isGameOver)
        {
            if(PlayerPrefs.GetInt("HighScore") < score)
            {
                PlayerPrefs.SetInt("HighScore", score);
                Debug.Log("New High Score is : " + score);
            } 
        }
        
    }

    private void SwipeDown()
    {
        touch = Input.GetTouch(0);
        if (touch.phase == TouchPhase.Moved && touch.deltaPosition.y < 0)
        {
            isFalling = true;
            rb2d.gravityScale = fallGravityScale;

        }
        else if (isFalling)
        {
            isFalling = false;
            rb2d.gravityScale = normalGravityScale;
        }
    }

    public void GameOver()  
    {
        isGameOver = true;
        anim.SetTrigger("death"); 
        StopCoroutine("IncreaseGameSpeed"); 
        StartCoroutine("ShowGameOverPanel"); 
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {

        if (collision.gameObject.CompareTag("Ground") || collision.gameObject.CompareTag("Platform"))
        {
            jumpCount = 0; 
            canJump = true;
        }

        if (collision.gameObject.CompareTag("Obstacle"))
        {
           GameOver();
        } 

        if (collision.gameObject.CompareTag("BottomDetector")) 
        {
            GameOver();
        }

        if (collision.gameObject.CompareTag("Enemy"))
        { 
           GameOver(); 
        }
    }

    IEnumerator IncreaseGameSpeed()
    {
        while (true)
        {
            yield return new WaitForSeconds(10); 

            if (runSpeed <= 50)
            {
                runSpeed += 0.3f;
                
                if(anim.speed <= 3) 
                {
                   anim.speed += 0.1f;
                }
                
                
            }

            if (GameObject.Find("Spawner").GetComponent<Spawner>().spawnInterval > 1.7)   
            {
                GameObject.Find("Spawner").GetComponent<Spawner>().spawnInterval -= 0.1f; 
            } 
        } 
    } 

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.tag == "Carrot")
        {
            Destroy(other.gameObject);
            score += 1;
            carrot.text = "Score : " + score.ToString(); 
        }
    } 

    IEnumerator ShowGameOverPanel()
    {
        yield return new WaitForSeconds(1); 
        GameOverPanel.SetActive(true);
        scoreText.SetActive(false);
        
        FinalScoreText.text = "Score : " + score.ToString();
        HighScoreText.text = "High Score : " + PlayerPrefs.GetInt("HighScore");
    }

    public void JumpButton()
    {
        if (canJump && !isGameOver)
        {
            rb2d.velocity = Vector3.up * 7.5f;
            anim.SetTrigger("jump");
            jumpCount += 1;
        }

        

    }

    
} 
