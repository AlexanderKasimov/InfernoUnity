using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    private RigidbodyMover rigidbodyMover;
  
    [HideInInspector]
    public Vector2 movementVector;

    private GameObject target;

    public float bigRadius = 6f;
    public float mediumRadius = 4f;
    public float smallRadius = 2f;

    private string curRadiusName;

    private float curRadius;

    private Vector2 movementPoint;

    public float attackRange = 1.5f;
    public float delayBeforeAttack = 0.3f;
    public float delayAfterAttack = 0.5f;
    public float attackBoxSize = 1f;

    [HideInInspector]
    public bool isAttacking = false;

    private Animator animator;

    private EnemyGraphicsController graphicsController;

    // Start is called before the first frame update
    void Start()
    {
        rigidbodyMover = GetComponent<RigidbodyMover>();
        target = FindObjectOfType<PlayerController>().gameObject;
        animator = GetComponent<Animator>();
        graphicsController = GetComponentInChildren<EnemyGraphicsController>();
    }

    // Update is called once per frame
    void Update()
    {
        //Update Graphics - будет запаздывать на 1 фрейм, но поидее без разницы
        graphicsController.UpdateGraphics(movementVector, isAttacking);
        //3 круга
        float distanceToTarget = (target.transform.position - transform.position).magnitude;        
        if (distanceToTarget > bigRadius)
        {
            if (!string.Equals(curRadiusName, "big"))
            {
                curRadiusName = "big";
                curRadius = bigRadius;
                GenerateMovementPoint();
            }
        }
        else        
        {
            if (distanceToTarget > mediumRadius)
            {
                if (!string.Equals(curRadiusName, "medium"))
                {
                    curRadiusName = "medium";
                    curRadius = mediumRadius;
                    GenerateMovementPoint();
                }
            }
            else
            {
                if (distanceToTarget > smallRadius)
                {
                    if (!string.Equals(curRadiusName, "small"))
                    {
                        curRadiusName = "small";
                        curRadius = smallRadius;
                        GenerateMovementPoint();
                    }
                }
                else
                {
                    if (!string.Equals(curRadiusName, "close"))
                    {
                        curRadiusName = "close";
                        curRadius = 0f;
                        GenerateMovementPoint();
                    }
                }

            }
        }

        movementVector = (((Vector2)target.transform.position + movementPoint) - (Vector2)transform.position).normalized;
        if (isAttacking)
        {
            rigidbodyMover.SetMovementVector(new Vector2(0f,0f));
            return;
        }

        if (distanceToTarget < attackRange )
        {
            StartCoroutine("Attack");
        }

        rigidbodyMover.SetMovementVector(movementVector);



    }

    IEnumerator Attack()
    {
        isAttacking = true;
        //Update Animator
        //animator.SetBool("isAttacking", isAttacking);
        //yield return new WaitForSeconds(delayBeforeAttack);
        //AttackAction();
        yield return new WaitForSeconds(delayAfterAttack);
        isAttacking = false;
        //animator.SetBool("isAttacking", isAttacking);  
       
    }

    public virtual void AttackAction()
    {
        RaycastHit2D hit = Physics2D.BoxCast((Vector2)transform.position + new Vector2(movementVector.x * attackRange, 0f), new Vector2(attackBoxSize, attackBoxSize), 0f, movementVector, 0f, LayerMask.GetMask("Player"));
        if (hit.collider != null)
        {
            DamageHandler damageHandler = hit.collider.gameObject.GetComponent<DamageHandler>();
            damageHandler.HandleDamage(1f);
        }
    }

    //AnimEvent - нужен рефактор после добавления дальников - пока не понятно как рефакторить
    public void DealDamage()
    {
        AttackAction();
    }

    private void GenerateMovementPoint()
    {
        movementPoint = Random.insideUnitCircle * curRadius;
    }

    private void OnDrawGizmos()
    {
        if (isAttacking)
        {
            Gizmos.color = Color.red;
            Gizmos.DrawWireCube((Vector2)transform.position + movementVector * attackRange, new Vector2(attackBoxSize, attackBoxSize));
        }

        if (target != null)
        {
            //Gizmos.DrawWireSphere(target.transform.position, movementPointRadius);
            Gizmos.DrawWireCube((Vector2)target.transform.position + movementPoint, new Vector2(0.2f, 0.2f));
            Gizmos.color = Color.red;
            Gizmos.DrawWireSphere(target.transform.position, bigRadius);
            Gizmos.color = Color.yellow;
            Gizmos.DrawWireSphere(target.transform.position, mediumRadius);
            Gizmos.color = Color.green;
            Gizmos.DrawWireSphere(target.transform.position, smallRadius);
        }

    }



}
