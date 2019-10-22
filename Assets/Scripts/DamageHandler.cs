using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageHandler : MonoBehaviour
{
    public float maxHP = 3f;

    private float curHP;

    public bool isDead = false;

    private HitReaction hitReactionObject;

    public DeathObject deathObjectPrefab;

    // Start is called before the first frame update
    void Start()
    {
        curHP = maxHP;
        hitReactionObject = GetComponentInChildren<HitReaction>();       
    }


    public void HandleDamage(float damage)
    {
        if (isDead)
        {
            return;
        }
        curHP -= damage;
        if (curHP <= 0)
        {
            HandleDeath();
            return;
        }

        //Blink Effect
        hitReactionObject.StartBlinking();    

    }

    private void HandleDeath()
    {
        isDead = true;
        DeathObject deathObject = Instantiate(deathObjectPrefab, transform.position, Quaternion.Euler(0, 0, 0));
        deathObject.lookDirection = GetComponent<EnemyController>().movementVector;
        Destroy(gameObject);
    }


    // Update is called once per frame
    void Update()
    {
        
    }



}
