using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackAction_MeleeStrike : AttackAction
{
    public Vector2 attackBoxSize = new Vector2(0.5f, 0.5f);

    override protected void DealDamage()
    {

        Collider2D collider = Physics2D.OverlapBox((Vector2)transform.position + new Vector2(movementVector.x, 0f).normalized * attackVectorMultiplayer, attackBoxSize, 0f, LayerMask.GetMask("Player"));
        if (collider != null)
        {
            DamageHandler damageHandler = collider.gameObject.GetComponent<DamageHandler>();
            damageHandler.HandleDamage(1f);
        }
    }

    //Draw debug attack box
    private void OnDrawGizmos()
    {      
        Gizmos.DrawWireCube((Vector2)transform.position + new Vector2(movementVector.x, 0f).normalized * attackVectorMultiplayer, attackBoxSize);    
    }

}
