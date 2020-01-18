using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Effect : MonoBehaviour
{   

    public float animationSpeed = 1f;

    // Start is called before the first frame update
    void Start()
    {        
        GetComponent<Animator>().speed = animationSpeed;
        float lifeTime = GetComponent<Animator>().GetCurrentAnimatorClipInfo(0)[0].clip.length / animationSpeed;   
        Destroy(gameObject, lifeTime);
    }

}
