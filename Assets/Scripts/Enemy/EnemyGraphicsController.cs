using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGraphicsController : MonoBehaviour
{

    private Vector2 movementVector;

    private Animator animator;

    private bool isAttacking = false;

    public float walkAnimSpeed = 0.7f;

    private float attackAnimLength;

    public string attackAnimName;

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }

    // Start is called before the first frame update
    void Start()
    {      
        animator.SetFloat("walkAnimSpeed", walkAnimSpeed);
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

    public void SetAttackParams(float attackLength)
    {
        //Найти длину анимации атаки - чтобы посчитать скорость проигрывания
        AnimationClip[] animClips = animator.runtimeAnimatorController.animationClips;
        foreach (AnimationClip animClip in animClips)
        {
            if (animClip.name == attackAnimName)
            {
                Debug.Log(animClip.name + " : " + animClip.length);
                attackAnimLength = animClip.length;
                break;
            }
        }
        float attackAnimSpeed = attackAnimLength / attackLength;
        animator.SetFloat("attackAnimSpeed", attackAnimSpeed);
    }

    //рефактор? - переход с булов на стейты?
    public void UpdateGraphics(Vector2 movementVector, bool isAttacking)
    {
        this.movementVector = movementVector;
        this.isAttacking = isAttacking;
        animator.SetBool("isAttacking", isAttacking);        
    }

}
