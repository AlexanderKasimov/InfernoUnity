using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{

    public GameObject muzzle;

    public Projectile projectilePrefab;


    private Vector2 shootDirection;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void Fire()
    {

    }


    // Update is called once per frame
    void Update()
    {
        Vector2 mousePosition = Input.mousePosition;
        Vector2 objectPosition = Camera.main.WorldToScreenPoint(transform.position);

        shootDirection = (mousePosition - objectPosition).normalized;

        float deltaRot = Mathf.Atan2(mousePosition.y - objectPosition.y, mousePosition.x - objectPosition.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0f, 0f, deltaRot);
    }
}
