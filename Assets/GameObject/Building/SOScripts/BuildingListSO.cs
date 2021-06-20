using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "BuildingList", menuName = "BuildingSO/Building List")]
public class BuildingListSO : ScriptableObject
{
    [SerializeField]
    List<BuildingSO> buildings = new List<BuildingSO>();

    public List<BuildingSO> Buildings => buildings;
}
