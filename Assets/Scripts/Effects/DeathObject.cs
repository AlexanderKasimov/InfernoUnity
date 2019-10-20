﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathObject : MonoBehaviour
{
    [HideInInspector]
    public Vector2 lookDirection;

    public float animationSpeed = 1f;

    private HitReaction hitReaction;

    // Start is called before the first frame update
    void Start()
    {
        GetComponent<Animator>().speed = animationSpeed;
        SpriteRenderer spriteRenderer = GetComponent<SpriteRenderer>();
        hitReaction = GetComponent<HitReaction>();
        //Blink at start
        hitReaction.StartBlinking();
        //Rotate DeathObjects to lookDirection in moment of death
        if (lookDirection.x < 0)
        {
            spriteRenderer.flipX = true;
        }
        if (lookDirection.x > 0)
        {
            spriteRenderer.flipX = false;
        }     
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
