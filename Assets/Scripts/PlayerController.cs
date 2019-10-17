using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    private RigidbodyMover rigidbodyMover;

    public Vector2 inputVector;

    public Weapon weapon;

    private float timeSinceFire = 0f;

    private Animator animator;

    private SpriteRenderer spriteRenderer;

    private float startYScale;

    // Start is called before the first frame update
    void Start()
    {
        rigidbodyMover = GetComponent<RigidbodyMover>();
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        startYScale = weapon.transform.localScale.y;

    }

    // Update is called once per frame
    void Update()
    {
        inputVector = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical")).normalized;
        rigidbodyMover.SetMovementVector(inputVector);
        animator.SetFloat("movementMagnitude", inputVector.magnitude);
        weapon.GetComponent<Animator>().SetFloat("movementMagnitude", inputVector.magnitude);
        timeSinceFire += Time.deltaTime;
        if (Input.GetButton("Fire1") && timeSinceFire > 60f/weapon.fireRate)
        {
            weapon.Fire();
            timeSinceFire = 0f;
        }

        float weaponRotation = weapon.transform.rotation.eulerAngles.z;
        if (weaponRotation > 90 && weaponRotation < 270)
        {
            spriteRenderer.flipX = true;
            weapon.transform.localScale = new Vector3(weapon.transform.localScale.x, -startYScale, weapon.transform.localScale.z);
            //weapon.GetComponent<SpriteRenderer>().flipY = true;
        }
        else
        {
            spriteRenderer.flipX = false;
            weapon.transform.localScale = new Vector3(weapon.transform.localScale.x, startYScale, weapon.transform.localScale.z);
            //weapon.GetComponent<SpriteRenderer>().flipY = false;
        }

    }
}
