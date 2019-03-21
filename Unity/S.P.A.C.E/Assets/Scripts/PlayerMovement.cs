using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D rb;
    private Animator animator;
    public float rotationSpeed;
    public float movementSpeed;
    private bool engineON = false;

    void Awake()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
        animator = gameObject.GetComponent<Animator>();
    }

    void FixedUpdate()
    {
        float forward = Input.GetAxis("Vertical");
        float horizontalMovement = Input.GetAxis("Horizontal");
        if (forward < 0)
            forward = 0;
        gameObject.transform.Rotate(0, 0, -rotationSpeed * horizontalMovement);
        rb.AddRelativeForce((new Vector3(0,1,0)) * movementSpeed * forward);
        if (forward != 0)
            engineON = true;
        else
            engineON = false;   
    }

     void Update()
    {
        animator.SetBool("EngineOFF", !engineON);
    }
}
