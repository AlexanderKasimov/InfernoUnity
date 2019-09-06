using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    private RigidbodyMover rigidbodyMover;

    public Vector2 inputVector;

    public Weapon weapon;

    private float timeSinceFire = 0f;

    // Start is called before the first frame update
    void Start()
    {
        rigidbodyMover = GetComponent<RigidbodyMover>();
    }

    // Update is called once per frame
    void Update()
    {
        inputVector = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
        rigidbodyMover.SetMovementVector(inputVector);
        timeSinceFire += Time.deltaTime;
        if (Input.GetButton("Fire1") && timeSinceFire > 60f/weapon.fireRate)
        {
            weapon.Fire();
            timeSinceFire = 0f;
        }

    }
}
