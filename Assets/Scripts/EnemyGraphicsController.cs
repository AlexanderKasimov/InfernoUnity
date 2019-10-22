using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGraphicsController : MonoBehaviour
{

    private Vector2 movementVector;

    private Animator animator;

    private bool isAttacking = false;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        //Rotate to movement - вынести в абстрактный класс, чтобы можно было кастомно поворачивать
        if (!isAttacking)
        {
            if (movementVector.x < 0)
            {
                GetComponent<SpriteRenderer>().flipX = true;
            }
            if (movementVector.x > 0)
            {
                GetComponent<SpriteRenderer>().flipX = false;
            }
        }

    }

    //рефактор? - переход с булов на стейты?
    public void UpdateGraphics(Vector2 movementVector, bool isAttacking)
    {
        this.movementVector = movementVector;
        this.isAttacking = isAttacking;
        animator.SetBool("isAttacking", isAttacking);  
    }

    public void OnDealDamage()
    {
        EnemyController enemyController = GetComponentInParent<EnemyController>();
        enemyController.DealDamage();
    }

}
