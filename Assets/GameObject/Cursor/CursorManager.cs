using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CursorManager : MonoBehaviour
{   
    [SerializeField]
    CursorSO defaultCursorData;

    public static CursorManager Instance { get; private set; }

    CursorSO activeCursorData;

    void Awake()
    {
        Instance = this;
        ResetActiveCursorData();
    }

    public void SetActiveCursorData(CursorSO cursorData)
    {
        activeCursorData = cursorData;
    }

    public void SetCursorTexture(HoverType hoverType)
    {
        Texture2D cursorTexture = activeCursorData.GetTexture(hoverType);
        Cursor.SetCursor(cursorTexture, Vector2.one, CursorMode.Auto);
    }

    public void ResetActiveCursorData()
    {
        SetActiveCursorData(defaultCursorData);
        SetCursorTexture(HoverType.Default);
    }
}
