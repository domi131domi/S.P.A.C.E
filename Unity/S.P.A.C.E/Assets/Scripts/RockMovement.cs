using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RockMovement : MonoBehaviour
{
    public float minimalMovSpeed, maximalMovSpeed;
    public float minimalRotSpeed, maximalRotSpeed;
    private Rigidbody2D rb;
    private float movSpeed;
    private float startRotation;
    private float rotSpeed;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Start()
    {
        movSpeed = Random.Range(minimalMovSpeed, maximalMovSpeed);
        startRotation = Random.Range(0, 360);
        rotSpeed = Random.Range(minimalRotSpeed, maximalRotSpeed);
        transform.Rotate(0,0,startRotation);
        rb.velocity = transform.right * movSpeed;
    }

    void FixedUpdate()
    {
        transform.Rotate(0,0,rotSpeed);
    }
}
