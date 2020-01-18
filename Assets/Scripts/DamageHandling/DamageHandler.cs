using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageHandler : MonoBehaviour
{
    public float maxHP = 3f;

    private float curHP;

    public bool isDead = false;

    private HitReaction hitReactionObject;    

    private DeathHandler deathHandler;

    private void Awake()
    {
        deathHandler = GetComponent<DeathHandler>();
        hitReactionObject = GetComponentInChildren<HitReaction>();
    }

    // Start is called before the first frame update
    void Start()
    {
        curHP = maxHP;             
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
            isDead = true;
            deathHandler.HandleDeath();
            return;
        }

        //Hit Reaction Effect
        hitReactionObject.StartHitReaction();    
    }

}
