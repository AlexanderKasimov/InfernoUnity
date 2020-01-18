using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackAction_MeleeStrike : AttackAction
{

    override protected void DealDamage()
    {
        RaycastHit2D hit = Physics2D.BoxCast((Vector2)transform.position + new Vector2(movementVector.x * attackDistance, 0f), new Vector2(attackBoxSize, attackBoxSize), 0f, movementVector, 0f, LayerMask.GetMask("Player"));
        if (hit.collider != null)
        {
            DamageHandler damageHandler = hit.collider.gameObject.GetComponent<DamageHandler>();
            damageHandler.HandleDamage(1f);
        }
    }

}
