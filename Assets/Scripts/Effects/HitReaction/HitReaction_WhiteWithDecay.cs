using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitReaction_WhiteWithDecay : HitReaction
{

    private bool isBlinking = false;
    public float startDelay = 0.03f;
    public float blinkDuration = 0.12f;
    public float endDelay = 0.02f;

    private SpriteRenderer spriteRenderer;

    public override void StartHitReaction()
    {
        if (!isBlinking)
        {
            spriteRenderer = GetComponent<SpriteRenderer>();
            StartCoroutine("Blink");
        }     
    }

    private IEnumerator Blink()
    {
        isBlinking = true;
        float t = 0f;
        float materialAlpha = 1f;    
        spriteRenderer.material.SetColor("_BlinkColor", new Color(1, 1, 1, 1));
        yield return new WaitForSeconds(startDelay);
        while (t <= blinkDuration)
        {
            t += Time.deltaTime;
            materialAlpha = Mathf.Lerp(1, 0, t / blinkDuration);
            spriteRenderer.material.SetColor("_BlinkColor", new Color(1, 1, 1, materialAlpha));        
            yield return null;
        }
        spriteRenderer.material.SetColor("_BlinkColor", new Color(1, 1, 1, 0));
        yield return new WaitForSeconds(endDelay);
        isBlinking = false;
    }

}
