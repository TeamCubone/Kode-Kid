using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class Player : MonoBehaviour
{
    // Config
    [SerializeField] float runSpeed = 6f;
    [SerializeField] float jumpSpeed = 6f;
    [SerializeField] Vector2 deathKick = new Vector2(25f, 25f);
    [SerializeField] List<RuntimeAnimatorController> characters;

    // State
    bool isAlive = true;
    RuntimeAnimatorController playerSprite;

    // Cached component references 
    Rigidbody2D myRigidBody;
    Animator myAnimator;
    CapsuleCollider2D myBodyCollider2D;
    BoxCollider2D feet;
    SpriteRenderer spriteRenderer;

    // Start is called before the first frame update

    // Message then methods
    void Start()
    {
        myRigidBody = GetComponent<Rigidbody2D>();
        myAnimator = GetComponent<Animator>();
        myBodyCollider2D = GetComponent<CapsuleCollider2D>();
        feet = GetComponent<BoxCollider2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        playerSprite = characters[PlayerPrefs.GetInt("Character")];
        UpdateSprite();
    }

    // Update is called once per frame, creates ability for player input
    void Update()
    {
        //if not alive, takes out the users ability for player input
        if (!isAlive)
        {
            return;
        }
        Run();
        FlipSprite();
        Jump();
        Death();
    }


    private void UpdateSprite()
    {
        myAnimator.runtimeAnimatorController = playerSprite;
    }

    private void Run()
    {
        float controlThrow = CrossPlatformInputManager.GetAxis("Horizontal");
        // vector will be our x and y, y is just keeping y as is.
        Vector2 playerVelocity = new Vector2(controlThrow * runSpeed, myRigidBody.velocity.y);
        myRigidBody.velocity = playerVelocity;

        // do run animation
        bool playerHasHorizontalSpeed = Mathf.Abs(myRigidBody.velocity.x) > Mathf.Epsilon;
        myAnimator.SetBool("Running", playerHasHorizontalSpeed);
    }

    private void Jump()
    {

        if (!feet.IsTouchingLayers(LayerMask.GetMask("Ground")))
        {
            return;
        }

        if (CrossPlatformInputManager.GetButtonDown("Jump"))
        {
            Vector2 jumpVelocityToAdd = new Vector2(0f, jumpSpeed);
            myRigidBody.velocity += jumpVelocityToAdd;
        }


    }

    private void FlipSprite()
    {
        //if player moves horizontal { reverse the current scaling of the x axis}
        
        //when the absolute value of the movement is greater than zero, the bool will return as true
        bool playerHasHorizontalSpeed = Mathf.Abs(myRigidBody.velocity.x) > Mathf.Epsilon;
        // if true
        if (playerHasHorizontalSpeed)
        {
            //vector 2 becomes +1 or -1, y is as is
            transform.localScale = new Vector2(Mathf.Sign(myRigidBody.velocity.x), 1f);
        }
    }

    //if the players collider is touching bug, then do death 
    private void Death()
    {
        // if the player has collision with the enemy layer, 
        if (myBodyCollider2D.IsTouchingLayers(LayerMask.GetMask("Enemies")))
        {
            isAlive = false;
            //triggers to state of death in unity hub
            myAnimator.SetTrigger("Death");
            //gets the ridgidbody to have a velocity of deathKick, deathKick throws player up in the air
            transform.Rotate(0, 0, 90);
            GetComponent<Rigidbody2D>().velocity = deathKick;
            FindObjectOfType<GameSession>().ProcessPlayerDeath();
        }

        if (myBodyCollider2D.IsTouchingLayers(LayerMask.GetMask("Waters")))
        {
            isAlive = false;
            //triggers to state of death in unity hub
            myAnimator.SetTrigger("Death");
            //gets the ridgidbody to have a velocity of deathKick, deathKick throws player up in the air
            transform.Rotate(0, 0, 90);
            GetComponent<Rigidbody2D>().velocity = deathKick;
            FindObjectOfType<GameSession>().ProcessPlayerDeath();
        }
    }
}
