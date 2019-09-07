using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public float damage = 1f;

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


    private void OnTriggerEnter2D(Collider2D collision)
    {
        DamageHandler damageHandler = collision.gameObject.GetComponent<DamageHandler>();
        if (damageHandler != null)
        {
            damageHandler.HandleDamage(damage);
            Destroy(gameObject);
        }
    }
}
