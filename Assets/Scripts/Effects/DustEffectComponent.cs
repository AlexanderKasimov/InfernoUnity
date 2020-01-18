using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DustEffectComponent : MonoBehaviour
{    
    public GameObject dustEffectPrefab;
    private RigidbodyMover rigidbodyMover;    

    // Start is called before the first frame update
    void Start()
    {       
        rigidbodyMover = GetComponent<RigidbodyMover>();
        InvokeRepeating("PlayVFX", 0f, 0.2f);
    }

    private void PlayVFX()
    {
        if (rigidbodyMover.movementVector.magnitude > 0)
        {
            GameObject dustObject = Instantiate(dustEffectPrefab, transform.position, Quaternion.identity);
            if (rigidbodyMover.movementVector.x < 0)
            {
                dustObject.GetComponent<SpriteRenderer>().flipX = true;
            }
            if (rigidbodyMover.movementVector.x > 0)
            {
                dustObject.GetComponent<SpriteRenderer>().flipX = false;
            }           
        }  
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
