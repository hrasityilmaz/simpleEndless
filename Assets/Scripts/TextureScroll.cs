using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextureScroll : MonoBehaviour
{

    Material backgroundMaterial;
    public float scrollSpeed;
    public bool scroll = true;


    private void Awake()
    {
        backgroundMaterial = GetComponent<Renderer>().material;
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void FixedUpdate()
    {
        if (scroll)
        {
            Vector2 offset = new Vector2(scrollSpeed * Time.time, 0);
            backgroundMaterial.mainTextureOffset = offset;
        }
    }
}
