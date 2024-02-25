using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(BoxCollider2D))]
public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 5f;
    [SerializeField] private float jumpForce = 10f;
    [SerializeField] private LayerMask groundLayer;

    private Rigidbody2D _rb2d;
    private BoxCollider2D _col2d;

    [SerializeField]private bool _isGrounded;

    private void Awake()
    {
        _rb2d = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        GroundCheck();
        Movement();
    }

    private void Movement()
    {
        var moveInput = Input.GetAxis("Horizontal");
        _rb2d.velocity = new Vector2(moveInput * moveSpeed, _rb2d.velocity.y);

        if (Input.GetKeyDown(KeyCode.Space) && _isGrounded)
        {
            _rb2d.velocity = new Vector2(_rb2d.velocity.x, jumpForce);
        }
    }
    
    private void GroundCheck()
    {
        _isGrounded = _rb2d.velocity.y < 0.05f ? Physics2D.Raycast(transform.position, Vector2.down, 0.1f, groundLayer) : false;
    }
}
