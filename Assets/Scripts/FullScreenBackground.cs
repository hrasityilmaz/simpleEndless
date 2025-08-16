using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FullScreenBackground : MonoBehaviour
{
    void Start()
    {
        ResizeSpriteToScreen();
    }

    void ResizeSpriteToScreen()
    {
        SpriteRenderer sr = GetComponent<SpriteRenderer>();
        
        // Calculate world space screen dimensions
        float worldScreenHeight = Camera.main.orthographicSize * 2f;
        float worldScreenWidth = worldScreenHeight * Camera.main.aspect;
        
        // Scale sprite to match screen size
        Vector3 newScale = transform.localScale;
        newScale.x = worldScreenWidth / sr.sprite.bounds.size.x;
        newScale.y = worldScreenHeight / sr.sprite.bounds.size.y;
        transform.localScale = newScale;
        
        // Center the background
        transform.position = Camera.main.transform.position;
        transform.position += new Vector3(0, 0, 10); // Move slightly in front of camera
    }
}
