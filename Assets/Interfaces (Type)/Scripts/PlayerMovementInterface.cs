using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(BoxCollider2D))]
public class PlayerMovementInterface : MonoBehaviour
{
    [SerializeField] private int damage = 1;
    [SerializeField] private float moveSpeed = 5f;
    [SerializeField] private float jumpForce = 10f;
    [SerializeField] private LayerMask groundLayer;
    
    [SerializeField] private float interactionRange;
    [SerializeField] private LayerMask damageLayer;
    [SerializeField] private LayerMask interactionLayer;

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
        TryInteract();
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

    private void TryInteract()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            InteractWithObjects();
        }
    }
    
    private void InteractWithObjects()
    {
        // first check IDamageables
        var damageHits = Physics2D.OverlapCircleAll(transform.position, interactionRange, damageLayer);

        if (damageHits.Length > 0)
        {
            foreach (var hit in damageHits)
            {
                hit.GetComponent<IDamageable>().TakeDamage(damage);
            }

            return;
        }
        
        var interactableHits = Physics2D.OverlapCircleAll(transform.position, interactionRange, interactionLayer);
        
        if (interactableHits.Length > 0)
        {
            var closestInteractable = Mathf.Infinity;
            var index = 0;

            for(var i = 0; i < interactableHits.Length; i++)
            {
                float tempDistance = Vector2.Distance(transform.position, interactableHits[i].transform.position);
                if (tempDistance < closestInteractable)
                {
                    closestInteractable = tempDistance;
                    index = i;
                }
            }
            
            interactableHits[index].GetComponent<IInteractable>().Interact();
        }

    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        
        Gizmos.DrawWireSphere(transform.position, interactionRange);
    }
}
