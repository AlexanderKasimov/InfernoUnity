using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DustEffectScript : MonoBehaviour
{
    private Rigidbody2D rb2d;
    public GameObject dustEffectPrefab;
    private RigidbodyMover rigidbodyMover;
    private GameObject tmp;

    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        rigidbodyMover = GetComponent<RigidbodyMover>();
        StartCoroutine("StartDustEffect");
    }

    private IEnumerator StartDustEffect()
    {
        while (true)
        {
            Debug.Log(rb2d.velocity.magnitude);
            if (rigidbodyMover.movementVector.magnitude > 0)
            {
                yield return new WaitForSeconds(Random.Range(0, 0.2f));
                
                tmp = Instantiate(dustEffectPrefab, new Vector3(transform.position.x, transform.position.y, transform.position.z), new Quaternion(0, 0, 0, 0));
                yield return new WaitForSeconds(0.1f);
                //Destroy(tmp);
            }
            yield return new WaitForSeconds(0);
        }        
    }


    // Update is called once per frame
    void Update()
    {
        
    }
}
