using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class CursorObject : MonoBehaviour
{
    [SerializeField]
    HoverType hoverType;

    void OnMouseEnter()
    {
        CursorManager.Instance.SetCursorTexture(hoverType);
    }

    void OnMouseExit()
    {
        CursorManager.Instance.SetCursorTexture(HoverType.Default);
    }
}
