using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerGraphicsController : MonoBehaviour
{

    private Vector2 movementVector;

    private float weaponRotation;

    private SpriteRenderer spriteRenderer;

    private Animator animator;


    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();      
    }

    // Update is called once per frame
    void Update()
    {
        //Orient to Weapon Rotation
        if (weaponRotation > 90 && weaponRotation < 270)
        {
            spriteRenderer.flipX = true; 
        }
        else
        {
            spriteRenderer.flipX = false;
        }
    }

    public void UpdateGraphics(Vector2 movementVector, float weaponRotation)
    {
        this.movementVector = movementVector;
        this.weaponRotation = weaponRotation;
        animator.SetFloat("movementMagnitude", movementVector.magnitude);
    }



}
