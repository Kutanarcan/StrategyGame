using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingFactory : Factory<BuildingSO>
{
    public override GameObject GetInstance(BuildingSO data)
    {
        return ObjectPooler.Instance.SpawnPoolObject(data.Prefab);
    }
}
