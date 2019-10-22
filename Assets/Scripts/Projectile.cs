﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public float damage = 1f;

    public Vector2 movementVector;
    private RigidbodyMover rigidbodyMover;

    public GameObject destroyEffect;

    private bool isHitted = false;

    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, 2f);
        rigidbodyMover = GetComponent<RigidbodyMover>();
        rigidbodyMover.SetMovementVector(movementVector);
        //rotate to movement - новый способ поворота вещей (Singed angle мб лучше) + мб лучше поворачивать сразу при спавне
        //если поворачивать здесь, то лучше инкапсулируется функционал, не нужно лезть в вепон чтобы менять поведение проджектайла
        float deltaRot = Mathf.Atan2(movementVector.y, movementVector.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0f, 0f, deltaRot);
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        //Защита от нанесения урона сразу N противникам
        if (isHitted)
        {
            return;
        }
        isHitted = true;

        DamageHandler damageHandler = collision.gameObject.GetComponent<DamageHandler>();
        if (damageHandler != null)
        {
            damageHandler.HandleDamage(damage);
            playVFX();
            Destroy(gameObject);
        }
        else
        {
            playVFX();
            Destroy(gameObject);
        }
    }

    public void playVFX()
    {
        Instantiate(destroyEffect, transform.position, Quaternion.Euler(0, 0, 0));
    }

}
