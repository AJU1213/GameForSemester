using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private Transform groundCheck;
    [SerializeField] private LayerMask groundLayer;
    
    private float movementSpeed = 5f;
    private float jumpForce = 10f;
    private bool isFacingRight = true;
    private float groundCheckRadius = 0.2f;
    private bool isGrounded = false;

    // Define an enum for different types of enemies
    public enum EnemyType
    {
        Basic,
        Flying,
        Boss
    }

    // Define a class for collectibles
    public class Collectible
    {
        public string Name { get; set; }
        public int Value { get; set; }

        public Collectible(string name, int value)
        {
            Name = name;
            Value = value;
        }

        public void Collect()
        {
            Debug.Log($"You collected {Name} worth {Value} points!");
        }
    }

    private void Update()
    {
        CheckGrounded();
        HandleJump();
        FlipSprite();
    }

    private void FixedUpdate()
    {
        HandleMovement();
    }

    private void HandleMovement()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        Vector2 movement = new Vector2(horizontal * movementSpeed, rb.velocity.y);
        rb.velocity = movement;
    }

    private void CheckGrounded()
    {
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, groundLayer);
    }

    private void HandleJump()
    {
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
        }

        if (Input.GetButtonUp("Jump") && rb.velocity.y > 0f)
        {
            rb.velocity = new Vector2(rb.velocity.x, rb.velocity.y * 0.5f);
        }
    }

    private void FlipSprite()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        if ((horizontal > 0f && !isFacingRight) || (horizontal < 0f && isFacingRight))
        {
            isFacingRight = !isFacingRight;
            Vector3 scale = transform.localScale;
            scale.x *= -1f;
            transform.localScale = scale;
        }
    }

    // Create a new enemy object of a specific type
    /*private void SpawnEnemy(EnemyType enemyType)
    {
        Enemy enemy = null;

        switch (enemyType)
        {
            case EnemyType.Basic:
                enemy = new BasicEnemy();
                break;
            case EnemyType.Flying:
                enemy = new FlyingEnemy();
                break;
            case EnemyType.Boss:
                enemy = new BossEnemy();
                break;
        }

        // Now you can use the new enemy object, for example:
        enemy.Attack();
    }*/

    // Create a new collectible object with a specific name and value
    private void SpawnCollectible(string name, int value)
    {
        Collectible collectible = new Collectible(name, value);

        // Now you can use the new collectible object, for example:
        collectible.Collect();
    }
}

