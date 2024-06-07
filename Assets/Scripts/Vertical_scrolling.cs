using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fish_scrolling : MonoBehaviour
{
    public float speed;
    [SerializeField]
    private Renderer bgRenderer;

    // Update is called once per frame
    void Update()
    {
        bgRenderer.material.mainTextureOffset += new Vector2(0, -speed*Time.deltaTime);
    }
}
