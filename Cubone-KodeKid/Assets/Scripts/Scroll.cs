using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scroll : MonoBehaviour
{
    /// <summary>
    /// Scroll speed
    /// </summary>
    public float Speed = 0.01f;

    // Update is called once per frame
    void Update()
    {
        Vector2 offset = new Vector2(Time.time * Speed, 0);
        GetComponent<Renderer>().material.mainTextureOffset = offset;
    }
}
