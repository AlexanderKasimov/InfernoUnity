using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageHandler : MonoBehaviour
{
    public float maxHP = 3f;

    private float curHP;

    public bool isDead = false;


    // Start is called before the first frame update
    void Start()
    {
        curHP = maxHP;
        //можно поставить true в isDead == бессмертие
        //isDead = false;
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
