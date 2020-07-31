using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Background : MonoBehaviour
{
    public float scrollSpeed;

    Renderer rend;

    void Start()
    {
        rend = GetComponent<Renderer>();
    }

    void Update()
    {
        float x = Mathf.Repeat(Time.time * scrollSpeed, 1);
        Vector2 v = new Vector2(x, 0);
        rend.sharedMaterial.SetTextureOffset("_MainTex", v);
    }
}

