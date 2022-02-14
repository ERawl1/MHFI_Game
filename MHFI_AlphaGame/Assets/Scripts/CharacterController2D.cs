using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterController2D : MonoBehaviour
{
    public float MovementSpeed = 3;
    public float JumpForce = 3;

    private Rigidbody2D _playerRB;

    void Start()
    {
        _playerRB = GetComponent<Rigidbody2D>();
    }

    
    void Update()
    {
        var horizontal = Input.GetAxis("Horizontal");
        transform.position += new Vector3(horizontal, 0, 0) * Time.deltaTime * MovementSpeed;

        if (!Mathf.Approximately(0, horizontal))
            transform.rotation = horizontal > 0 ? Quaternion.Euler(0, 180, 0) : Quaternion.identity;

        if (Input.GetButtonDown("Jump") && Mathf.Abs(_playerRB.velocity.y) < 0.001f)
        {
            _playerRB.AddForce(new Vector2(0, JumpForce), ForceMode2D.Impulse);
        }
    }
}
