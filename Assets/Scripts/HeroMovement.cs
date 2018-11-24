using UnityEngine;

public class HeroMovement : MonoBehaviour
{
    public float runSpeed = 5f;

    float horizontalMove;
    bool jump = false;
    bool crouch = false;

    private Animator _animator;
    private PlayerController _controller;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
        _controller = GetComponent<PlayerController>();
    }

    void Update()
    {
        horizontalMove = Input.GetAxis("Horizontal") * runSpeed;
        Debug.Log(horizontalMove);
        _animator.SetFloat("RunSpeed", Mathf.Abs(horizontalMove));

        jump |= Input.GetButtonDown("Jump");

        if (Input.GetButtonDown("Crouch"))
        {
            crouch = true;
        }
        else if (Input.GetButtonUp("Crouch"))
        {
            crouch = false;
        }
    }

    void FixedUpdate()
    {
        // Move the character
        _controller.Move(horizontalMove * Time.fixedDeltaTime, jump);
        jump = false;
    }
}
