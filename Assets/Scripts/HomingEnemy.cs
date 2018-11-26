using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class HomingEnemy : MonoBehaviour
{
    public Transform target;
    public float speed = 5f;
    public float rotationSpeed = 200f;
    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        Vector2 direction = (Vector2)target.position - rb.position;
        direction.Normalize();

        float rotateAmount = Vector3.Cross(direction, transform.up).z * -1;

        rb.angularVelocity = rotateAmount * rotationSpeed;
        rb.velocity = transform.up * speed;
    }

    void OnCollisionEnter2D()
    {
        if(GameManager.instance)
        {
            //do real stuff here
        }

        Debug.Log("Player hit");
    }
}
