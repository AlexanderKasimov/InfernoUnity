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

    private SpriteRenderer spriteRenderer;
    // Start is called before the first frame update
    void Start()
    {
        curHP = maxHP;
        spriteRenderer = GetComponent<SpriteRenderer>();
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
        //hitMaskObject.GetComponent<SpriteRenderer>().material.SetColor("_BlinkColor", new Color(1, 1, 1, 1));
        spriteRenderer.material.SetColor("_BlinkColor", new Color(1, 1, 1, 1));
        while (t <= blinkDuration)
        {
            t += Time.deltaTime;
            materialAlpha = Mathf.Lerp(1, 0, t/blinkDuration);
            spriteRenderer.material.SetColor("_BlinkColor", new Color(1, 1, 1, materialAlpha));
            //hitMaskObject.GetComponent<SpriteRenderer>().material.SetColor("_BlinkColor", new Color(1, 1, 1, materialAlpha));
            yield return null;
        }
        spriteRenderer.material.SetColor("_BlinkColor", new Color(1, 1, 1, 0));
        isBlinking = false;
    }


    // Update is called once per frame
    void Update()
    {
        
    }



}
