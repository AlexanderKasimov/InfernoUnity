﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RigidbodyMover : MonoBehaviour
{
    private Rigidbody2D rb;

    public float speed = 2f;
    [HideInInspector]
    public Vector2 movementVector;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();     
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetMovementVector(Vector2 inputVector)
    {
        movementVector = inputVector;
    }

    private void FixedUpdate()
    {
        rb.MovePosition(rb.position + movementVector * speed * Time.fixedDeltaTime);
    }
}
