using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Effect : MonoBehaviour
{   
  
    public float animationSpeed = 1f;
    public bool isAutoplayed = false;

    // Start is called before the first frame update
    void Start()
    {        
        if (isAutoplayed)
        {
            PlayEffect(animationSpeed);
        }
    }

    public void PlayEffect(float animSpeed)
    {
        GetComponent<Animator>().speed = animSpeed;
        float lifeTime = GetComponent<Animator>().GetCurrentAnimatorClipInfo(0)[0].clip.length / animSpeed;
        Destroy(gameObject, lifeTime);
    }

    public float GetAnimLength()
    {
        return GetComponent<Animator>().GetCurrentAnimatorClipInfo(0)[0].clip.length;
    }


}
