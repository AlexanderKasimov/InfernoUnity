using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    private RigidbodyMover rigidbodyMover;

    private Vector2 movementVector;

    private GameObject target;

    public float bigRadius = 6f;
    public float mediumRadius = 4f;
    public float smallRadius = 2f;

    private string curRadiusName;

    private float curRadius;

    private Vector2 movementPoint;


    // Start is called before the first frame update
    void Start()
    {
        rigidbodyMover = GetComponent<RigidbodyMover>();
        target = FindObjectOfType<PlayerController>().gameObject;
    }

    // Update is called once per frame
    void Update()
    {
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

        movementVector = (movementPoint - (Vector2)transform.position).normalized;

        rigidbodyMover.SetMovementVector(movementVector);

    }

    private void GenerateMovementPoint()
    {
        movementPoint = Random.insideUnitCircle * curRadius;
    }

    private void OnDrawGizmos()
    {
        //if (isAttacking)
        //{
        //    Gizmos.color = Color.red;
        //    Gizmos.DrawWireCube((Vector2)transform.position + movementDir * 0.3f, new Vector2(0.5f, 0.5f));
        //}

        if (target != null)
        {
            //Gizmos.DrawWireSphere(target.transform.position, movementPointRadius);
            Gizmos.DrawWireCube(movementPoint, new Vector2(0.2f, 0.2f));
            Gizmos.color = Color.red;
            Gizmos.DrawWireSphere(target.transform.position, bigRadius);
            Gizmos.color = Color.yellow;
            Gizmos.DrawWireSphere(target.transform.position, mediumRadius);
            Gizmos.color = Color.green;
            Gizmos.DrawWireSphere(target.transform.position, smallRadius);
        }

    }

}
