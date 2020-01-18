using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitReaction_SimpleWhite : HitReaction
{
    private bool isBlinking = false;
    public float blinkDuration = 0.2f;

    private Material defaultMat;
    public Material hitMaterial;       

    private SpriteRenderer spriteRenderer;

    public override void StartHitReaction()
    {
        if (!isBlinking)
        {
            spriteRenderer = GetComponent<SpriteRenderer>();
            defaultMat = spriteRenderer.material;
            StartCoroutine("Blink");
        } 
    }

    private IEnumerator Blink()
    {
        isBlinking = true;
        spriteRenderer.material = hitMaterial;
        yield return new WaitForSeconds(blinkDuration);
        spriteRenderer.material = defaultMat;
        isBlinking = false;
    }

}
