using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] float _moveSpeed = 2;
    [SerializeField] float _jumpForce = 100;

    SpriteRenderer spriteRenderer;
    Animator animator;

    Rigidbody2D rb;

    [SerializeField] bool _isInTheAir;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();

    }
    void Update()
    {
        float input = Input.GetAxis("Horizontal");
        rb.velocity = new Vector2(input * _moveSpeed, rb.velocity.y);
        if (input != 0)
            spriteRenderer.flipX = input > 0;
        animator.SetBool("IsMoving", input != 0);

        if (Input.GetKeyDown(KeyCode.Space) && !_isInTheAir)
        {
            rb.AddForce(Vector2.up * _jumpForce);
            _isInTheAir = true;
        }
        animator.SetBool("IsInTheAir", _isInTheAir);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.contacts[0].point.y < transform.position.y)
        {
            _isInTheAir = false;
            animator.SetBool("IsInTheAir", _isInTheAir);
        }
    }
}
