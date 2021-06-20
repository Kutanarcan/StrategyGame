using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "PoolInfoAsset", menuName = "Pool/Info")]
public class Poolnfo : ScriptableObject
{
    public List<PoolInfoAsset> poolInfos = new List<PoolInfoAsset>();

    public void AddItemToPoolList(PoolInfoAsset poolInfoAsset)
    {
        poolInfos.Add(poolInfoAsset);
    }

    public void ClearPoolList() => poolInfos.Clear();
}

[System.Serializable]
public class PoolInfoAsset
{
    [HideInInspector]
    public string name;
    public GameObject prefab;
    public int size;
}
