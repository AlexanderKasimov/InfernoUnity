using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public Vector2 movementVector;
    private RigidbodyMover rigidbodyMover;

    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, 2f);
        rigidbodyMover = GetComponent<RigidbodyMover>();
        rigidbodyMover.SetMovementVector(movementVector);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
