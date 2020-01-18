using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackAction_CastFireball : AttackAction
{
    public Projectile fireballPrefab;
    //public GameObject castPoint;


    override protected void DealDamage()
    {
        GameObject target = GameObject.FindGameObjectWithTag("Player");
        //Остановка если игрок мертв
        if (target == null)
        {
            return;
        }

        Vector2 castDirection = (target.transform.position - transform.position).normalized;

        Projectile projectile = Instantiate(fireballPrefab, transform.position + (Vector3)castDirection * attackDistance, Quaternion.identity);
        projectile.movementVector = castDirection;


        //RaycastHit2D hit = Physics2D.BoxCast((Vector2)transform.position + new Vector2(movementVector.x * attackDistance, 0f), new Vector2(attackBoxSize, attackBoxSize), 0f, movementVector, 0f, LayerMask.GetMask("Player"));
        //if (hit.collider != null)
        //{
        //    DamageHandler damageHandler = hit.collider.gameObject.GetComponent<DamageHandler>();
        //    damageHandler.HandleDamage(1f);
        //}
    }

}
