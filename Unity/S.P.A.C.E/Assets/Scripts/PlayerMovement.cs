using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float rotationSpeed;
    public float movementSpeed;
    public float maxVelocity;
    public int maxHp;
    public float relativeForceSens;
    public float insensivityTimes;
    private SpriteRenderer sr;
    private Rigidbody2D rb;
    private Animator animator;
    private bool engineON = false;
    private bool corkscrew = false;
    private bool visible = true;
    private int actualHp;

    void Awake()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
        sr = gameObject.GetComponent<SpriteRenderer>();
        animator = gameObject.GetComponent<Animator>();
    }

    void Start()
    {
        actualHp = maxHp;
    }

    void FixedUpdate()
    {
        float forward = Input.GetAxis("Vertical");
        float horizontalMovement = Input.GetAxis("Horizontal");
        if (forward < 0)
            forward = 0;
        gameObject.transform.Rotate(0, 0, -rotationSpeed * horizontalMovement);
        
        rb.AddRelativeForce((new Vector2(0,1)) * movementSpeed * forward);
        rb.AddForce((new Vector2(-rb.velocity.x * relativeForceSens, -rb.velocity.y * relativeForceSens)));

        if (forward != 0)
            engineON = true;
        else
            engineON = false;
        if(corkscrew)
        {
            rb.AddRelativeForce((new Vector2(1, 1)) * movementSpeed * forward);
            transform.Rotate(0, 0, rotationSpeed * 1.5f);
        }
        
    }

     void Update()
    {
        animator.SetBool("EngineOFF", !engineON);
        if (Input.GetKeyDown("r"))
            GetHit();
    }

    void ChangeVisibility()
    {
        visible = !visible;
        if (visible)
            sr.enabled = true;
        else
            sr.enabled = false;
    }

    void GetHit()
    {
        for (int i = 0; i < insensivityTimes; ++i)
            Invoke("ChangeVisibility", (float)(0.2 * i));
        corkscrew = true;
        Invoke("EndCorkscrew", (float)(0.2 * (insensivityTimes - 1)));
    }

    private void EndCorkscrew() { corkscrew = false; }

}
