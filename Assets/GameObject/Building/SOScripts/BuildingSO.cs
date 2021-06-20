using UnityEngine;

public abstract class BuildingSO : ScriptableObject
{
    [SerializeField]
    string buildingName;
    [SerializeField]
    GameObject prefab;
    [SerializeField]
    Sprite sprite;
    [SerializeField]
    CursorSO cursorData;

    public string BuildingName => buildingName;
    public GameObject Prefab => prefab;
    public Sprite Sprite => sprite;
    public CursorSO CursorData => cursorData;
}
