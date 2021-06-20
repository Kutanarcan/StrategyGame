using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile : MonoBehaviour
{
    [SerializeField]
    Color baseColor, offsetColor;
    [SerializeField]
    SpriteRenderer spriteRenderer;

    public void Init(bool isOffset, int x, int y)
    {
        transform.name = $"Tile : ({x},{y})";
        spriteRenderer.color = isOffset ? offsetColor : baseColor;
    }
}
