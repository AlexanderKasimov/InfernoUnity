using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Effect : MonoBehaviour
{
    //public float lifeTime = 1f;

    public float animationSpeed = 1f;


    // Start is called before the first frame update
    void Start()
    {
        //Destroy(gameObject, lifeTime);
        GetComponent<Animator>().speed = animationSpeed;
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void AnimFinished()
    {
        //Debug.Log("AnimFinished");
        Destroy(gameObject);
    }

}
