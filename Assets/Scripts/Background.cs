using System;
using UnityEngine;

public class Background : MonoBehaviour
{
    [SerializeField] private Material bgMaterial;
    [SerializeField] private float scrollSpeed = 0.03f;

    private void Update()
    {
        var dir = Vector2.up;
        bgMaterial.mainTextureOffset += Time.deltaTime * scrollSpeed * dir;
    }
}