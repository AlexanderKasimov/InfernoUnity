using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackAction_CastFireball : AttackAction
{
    public Projectile fireballPrefab;   
    
    override protected void DealDamage()
    {
        GameObject target = GameObject.FindGameObjectWithTag("Player");
        //Остановка если игрок мертв
        if (target == null)
        {
            return;
        }

        Vector2 castDirection = (target.transform.position - transform.position).normalized;

        Projectile projectile = Instantiate(fireballPrefab, transform.position + (Vector3)castDirection * attackVectorMultiplayer, Quaternion.identity);
        projectile.movementVector = castDirection;

    }

}
