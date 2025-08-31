using System;
using UnityEngine;

public class Parallax : MonoBehaviour
{
    private MeshRenderer meshRenderer;
    public float speed = 0.3f;

    private void Awake()
    {
        meshRenderer = GetComponent<MeshRenderer>();    
    }

    private void Update()
    {
        meshRenderer.material.mainTextureOffset += new Vector2(speed * Time.deltaTime, 0);
    }
}
