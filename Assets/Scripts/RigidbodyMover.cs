using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RigidbodyMover : MonoBehaviour
{
    private Rigidbody2D rb;
    public float speed = 2f;
    private Vector2 movementVector;

    //private PlayerController playerController;



    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        //playerController = GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        //SetMovementVector(playerController.inputVector);
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
