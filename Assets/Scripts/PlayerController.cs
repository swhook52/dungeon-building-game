using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public int speed;
    public bool isOnGround;
    public float jumpForce;
    public int health;

    Rigidbody2D rb;
    Vector3 jump;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        jump = new Vector3(0, 2f, 0);
        health = 10;
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        // Verify the collision is with a ground
        if (collision.gameObject.CompareTag("Ground"))
        {
            isOnGround = true;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Check is the collided object is a healthItem
        if (collision.gameObject.CompareTag("HealthItem"))
        {
            collision.gameObject.SetActive(false);
        }
    }

    void FixedUpdate()
    {
        // Detect if the user should (and can) jump
        if (isOnGround && Input.GetKeyDown(KeyCode.W))
        {
            isOnGround = false;
            rb.AddForce(jump * jumpForce, ForceMode2D.Impulse);
        }

        // Adjust for movement
        float moveHorizontal = Input.GetAxis("Horizontal") * speed;
        Vector2 movement = new Vector2(moveHorizontal, 0);
        rb.AddForce(movement, ForceMode2D.Force);
    }
}
