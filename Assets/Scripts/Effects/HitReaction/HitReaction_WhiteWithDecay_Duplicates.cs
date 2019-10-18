using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitReaction_WhiteWithDecay_Duplicates : HitReaction
{
    private GameObject hitMaskObject;

    private bool isBlinking = false;
    public float blinkDuration = 0.2f;  

    public override void StartBlinking()
    {
        if (!isBlinking)
        {
            hitMaskObject = GetComponent<DamageHandler>().hitMaskObject;        
            StartCoroutine("Blink");
        }
    }

    public override IEnumerator Blink()
    {
        isBlinking = true;
        float t = 0f;
        float materialAlpha = 1f;
        hitMaskObject.GetComponent<SpriteRenderer>().material.SetColor("_BlinkColor", new Color(1, 1, 1, 1));
        while (t <= blinkDuration)
        {
            t += Time.deltaTime;
            materialAlpha = Mathf.Lerp(1, 0, t / blinkDuration);
            hitMaskObject.GetComponent<SpriteRenderer>().material.SetColor("_BlinkColor", new Color(1, 1, 1, materialAlpha));
            yield return null;
        }
        hitMaskObject.GetComponent<SpriteRenderer>().material.SetColor("_BlinkColor", new Color(1, 1, 1, 0));
        isBlinking = false;
    }


}
