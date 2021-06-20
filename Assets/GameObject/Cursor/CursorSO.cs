using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "CursorData", menuName = "Cursor/CursorData")]
public class CursorSO : ScriptableObject
{
    [SerializeField]
    CursorData defaultCursorData;
    [SerializeField]
    List<CursorData> cursorDatas = new List<CursorData>();

    Dictionary<HoverType, Texture2D> cursorDataDict = new Dictionary<HoverType, Texture2D>();

    void OnEnable()
    {
        for (int i = 0; i < cursorDatas.Count; i++)
        {
            cursorDataDict[cursorDatas[i].hoverType] = cursorDatas[i].cursorTextures;
        }
    }

    public Texture2D GetTexture(HoverType hoverType)
    {
        if (cursorDataDict.ContainsKey(hoverType))
        {
            return cursorDataDict[hoverType];
        }

        return defaultCursorData.cursorTextures;
    }
}

[System.Serializable]
public struct CursorData
{
    public HoverType hoverType;
    public Texture2D cursorTextures;
}

public enum HoverType
{
    Default,
    Building,
    Unit
}