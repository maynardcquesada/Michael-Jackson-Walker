using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private CharacterController2D controller;
    [SerializeField] private float runSpeed = 40f;
    [SerializeField] private Animator animator;
    private float horizontalMove = 0f;
    private bool jump = false;
    private bool attack = false;
    private bool death = false;

    // Update is called once per frame
    void Update()
    {
        horizontalMove = Input.GetAxisRaw("Horizontal") * runSpeed;

        animator.SetFloat("Speed", Mathf.Abs(horizontalMove));

        if (Input.GetButtonDown("Jump"))
        {
            jump = true;
            animator.SetBool("IsJumping", true);
        }

        if (Input.GetKeyDown(KeyCode.E))
        {
            attack = true;
            animator.SetBool("IsAttacking", true);
        }

        if (Input.GetKeyUp(KeyCode.E))
        {
            attack = false;
            animator.SetBool("IsAttacking", false);
        }

        if (Input.GetKeyDown(KeyCode.R))
        {
            animator.SetBool("IsDead", true);
        }

        if (Input.GetKeyDown(KeyCode.Q))
        {
            animator.SetBool("IsHit", true);
        }

        if (Input.GetKeyUp(KeyCode.Q))
        {
            animator.SetBool("IsHit", false);
        }
    }

    public void OnLanding()
    {
        animator.SetBool("IsJumping", false);
    }

    private void FixedUpdate()
    {
        // Move our character
        controller.Move(horizontalMove * Time.fixedDeltaTime, false, jump);
        jump = false;
    }
}
