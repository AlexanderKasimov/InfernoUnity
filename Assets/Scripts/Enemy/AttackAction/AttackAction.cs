using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class AttackAction : MonoBehaviour
{
    public float attackLength = 0.5f;
    //0 -> 1 процент от времени атаки, на котором произойдет нанесение урона -> 0.5 -> 50% -> в середине атаки
    public float attackPoint = 0.5f;

    public float delayAfterAttack = 0.2f;

    protected Vector2 movementVector;
    [HideInInspector]
    public bool isAttacking = false;


    public float attackDistance = 0.7f;
    public float attackBoxSize = 0.5f;

    public void IsInRange(Vector2 movementVector)
    {
        if (!isAttacking)
        {
            this.movementVector = movementVector;
            StartCoroutine("Attack");
        }
    }

    private IEnumerator Attack()
    {
        isAttacking = true;
        yield return new WaitForSeconds(attackLength * attackPoint);
        DealDamage();
        yield return new WaitForSeconds(attackLength * (1 - attackPoint));
        yield return new WaitForSeconds(delayAfterAttack);
        isAttacking = false;
    }

    protected abstract void DealDamage();
}
