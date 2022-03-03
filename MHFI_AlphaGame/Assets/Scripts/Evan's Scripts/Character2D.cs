using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character2D : MonoBehaviour
{
    private Rigidbody2D _playerRB;

    public float moveSpeed;
    public float jumpForce;
    private bool isJumping;
    private float moveHorizontal;
    private float moveVertical;

    void Start()
    {
        _playerRB = gameObject.GetComponent<Rigidbody2D>();

        
        isJumping = false;
    }

    
    void Update()
    {
        moveHorizontal = Input.GetAxisRaw("Horizontal");
        moveVertical = Input.GetAxisRaw("Vertical");
       // FlipCharacter();
    }

    void FixedUpdate()
    {
        if (moveHorizontal > 0.1f || moveHorizontal < -0.1f)
        {
            _playerRB.AddForce(new Vector2(moveHorizontal * moveSpeed, 0f), ForceMode2D.Impulse);
        }

        if (!isJumping && moveVertical > 0.1f)
        {
            _playerRB.AddForce(new Vector2(0f, moveVertical * jumpForce), ForceMode2D.Impulse);
        }              
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            isJumping = false;
        }

        if (collision.gameObject.tag == "OneWayPlatform")
        {
            isJumping = false;
        }

    }

    void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            isJumping = true;
        }

        if (collision.gameObject.tag == "OneWayPlatform")
        {
            isJumping = true;
        }
    }

    /*private void FlipCharacter()
    {
        bool playerIsMoving = Mathf.Abs(_playerRB.velocity.x) > 0.1;

        if (playerIsMoving)
        {
            transform.localScale = new Vector2(Mathf.Sign(_playerRB.velocity.x)* 1, 1);
        }
    }*/
}
