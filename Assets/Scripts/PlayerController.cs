using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    private RigidbodyMover rigidbodyMover;

    public Vector2 inputVector;

    public Weapon weapon;

    private float timeSinceFire = 0f;

    private PlayerGraphicsController graphicsController;

    // Start is called before the first frame update
    void Start()
    {
        rigidbodyMover = GetComponent<RigidbodyMover>(); 
        graphicsController = GetComponentInChildren<PlayerGraphicsController>();
    }

    // Update is called once per frame
    void Update()
    {
        //Обновить графику в начале фрейма - с задержкой на 1 фрейм
        graphicsController.UpdateGraphics(inputVector, weapon.transform.rotation.eulerAngles.z);
        weapon.GetComponent<Animator>().SetFloat("movementMagnitude", inputVector.magnitude);

        inputVector = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical")).normalized;
        rigidbodyMover.SetMovementVector(inputVector);        

        //Инпут стрельбы
        timeSinceFire += Time.deltaTime;
        if (Input.GetButton("Fire1") && timeSinceFire > 60f/weapon.fireRate)
        {
            weapon.Fire();
            timeSinceFire = 0f;
        }

    }
}
