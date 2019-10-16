using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CursorChanger : MonoBehaviour
{
    public Texture2D texture;


    // Start is called before the first frame update
    void Start()
    {
        Cursor.SetCursor(texture, new Vector2(texture.width/2, texture.width/2), CursorMode.ForceSoftware);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
