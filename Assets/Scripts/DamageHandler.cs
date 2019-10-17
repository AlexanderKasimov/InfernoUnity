using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageHandler : MonoBehaviour
{
    public float maxHP = 3f;

    private float curHP;

    public bool isDead = false;

    [HideInInspector]
    public GameObject hitMaskObject;

    private bool isBlinking = false;
    public float blinkDuration = 0.2f;


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

        //Blink Effect - лучше вынести в другой модуль? разделить графику от логики - зачем?
        if (!isBlinking)
        {
            StartCoroutine("Blink");
        }

    }

    private void HandleDeath()
    {
        isDead = true;
        Destroy(gameObject);
    }

    private IEnumerator Blink()
    {
        isBlinking = true;
        float t = 0f;
        float materialAlpha = 1f;
        hitMaskObject.GetComponent<SpriteRenderer>().material.SetColor("_BlinkColor", new Color(1, 1, 1, 1));
        while (t <= blinkDuration)
        {
            t += Time.deltaTime;
            materialAlpha = Mathf.Lerp(1, 0, t/blinkDuration);
            hitMaskObject.GetComponent<SpriteRenderer>().material.SetColor("_BlinkColor", new Color(1, 1, 1, materialAlpha));
            yield return null;
        }
        isBlinking = false;
    }


    // Update is called once per frame
    void Update()
    {
        
    }



}
