using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public float enemySpeed;
    private PlayerController playerController;
    public BoxCollider2D enemyCollider;
    Rigidbody2D rb;
    //Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        playerController = FindObjectOfType <PlayerController>();
        enemyCollider = GetComponent<BoxCollider2D>();
        rb = GetComponent<Rigidbody2D>();

        //anim = GetComponent<Animator>();

    }

    // Update is called once per frame
    void Update()  
    {
        
         if(playerController.isGameOver == false)
        {
           transform.position = Vector3.left * enemySpeed * Time.deltaTime + transform.position;
        }

        else if (playerController.isGameOver == true)
        {
            if (gameObject.CompareTag("Enemy"))
            {
                rb.gravityScale = 0;
                enemyCollider.enabled = false;
            }
        }


    }

   
}
