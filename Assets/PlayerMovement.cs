using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] float boostModifier = 2f;
    [SerializeField] Animator animator;
    Rigidbody2D rb;
    Vector2 inputDirection = Vector2.zero;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();

    }
    void OnMove2(InputValue value)
    {
        Vector2 movementDir = value.Get<Vector2>();
        Vector2 boostDirection = movementDir.normalized;
        rb.AddForce(boostDirection * 25, ForceMode2D.Impulse);
    }
    void OnMove(InputValue value)
    {
        Vector2 movementDir = value.Get<Vector2>();
        Debug.Log(movementDir);

        //rb.AddForce(movementDir * boostModifier, ForceMode2D.Impulse);
        rb.velocity = movementDir * 3;
        inputDirection = movementDir;
        if (Mathf.Approximately(rb.velocity.magnitude, 0))
        {
            animator.SetBool("running", false);
        }
        else
        {
            animator.SetBool("running", true);
        }

    }

    private void Update()
    {
        rb.AddForce(inputDirection * boostModifier);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("Meowch!");
    }
}