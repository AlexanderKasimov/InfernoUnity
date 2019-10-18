using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageHandler : MonoBehaviour
{
    public float maxHP = 3f;

    private float curHP;

    //можно поставить true в isDead == бессмертие
    public bool isDead = false;

    private HitReaction hitReactionObject;
    //для HitReaction использующего дубликаты
    [HideInInspector]
    public GameObject hitMaskObject;

    // Start is called before the first frame update
    void Start()
    {
        curHP = maxHP;
        hitReactionObject = GetComponent<HitReaction>();
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
            HandleDeath();
        }

        //Blink Effect - лучше вынести в другой модуль? разделить графику от логики - зачем?
        hitReactionObject.StartBlinking();    

    }

    private void HandleDeath()
    {
        isDead = true;
        Destroy(gameObject);
    }


    // Update is called once per frame
    void Update()
    {
        
    }



}
