using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitReaction_notCompleteWhiteWithDecay : HitReaction
{

    private bool isBlinking = false;
    public float blinkDuration = 0.2f;

    private SpriteRenderer spriteRenderer;

    public override void StartBlinking()
    {
        if (!isBlinking)
        {
            spriteRenderer = GetComponent<SpriteRenderer>();
            StartCoroutine("Blink");
        }     
    }

    public override IEnumerator Blink()
    {
        isBlinking = true;
        float t = 0f;
        float materialAlpha = 1f;    
        spriteRenderer.material.SetColor("_BlinkColor", new Color(1, 1, 1, 1));
        while (t <= blinkDuration)
        {
            t += Time.deltaTime;
            materialAlpha = Mathf.Lerp(1, 0, t / blinkDuration);
            spriteRenderer.material.SetColor("_BlinkColor", new Color(1, 1, 1, materialAlpha));        
            yield return null;
        }
        spriteRenderer.material.SetColor("_BlinkColor", new Color(1, 1, 1, 0));
        isBlinking = false;
    }

}
