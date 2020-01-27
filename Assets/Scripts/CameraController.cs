using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    private GameObject player;
    public float interpSpeed = 5f;
    //0..1 How close camera to cursor on vector between player and cursor (1 - camera on cursor/ 0 - camera on player)
    public float followingCursorRatio = 0.1f;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void LateUpdate()
    {        
        if (player == null)
        {
            return;
        }

        Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);      
        Vector2 cameraVector = mousePosition - (Vector2)player.transform.position;
        Vector2 newCameraPosition = Vector2.Lerp(transform.position,(Vector2)player.transform.position + cameraVector * followingCursorRatio, Time.deltaTime * interpSpeed);
        transform.position = (Vector3)newCameraPosition + new Vector3(0, 0, -10);
    }
}
