using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridGenerator : MonoBehaviour
{
    [SerializeField]
    float height;
    [SerializeField]
    float width;
    [SerializeField]
    float offset;

    [Space]
    [SerializeField]
    Tile tile;

    void Awake()
    {
        GeneratGrideMap();
    }

    void GeneratGrideMap()
    {
        for (int x = 0; x < width; x++)
        {
            for (int y = 0; y < height; y++)
            {
                var tmpTile = Instantiate(tile, transform);
                tmpTile.transform.position = new Vector2(x + offset, y + offset);

                var isOffset = (x % 2 == 0 && y % 2 != 0) || (x % 2 != 0 && y % 2 == 0);
                tmpTile.Init(isOffset, x, y);
            }
        }
    }
}
