using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Produce Building", menuName = "BuildingSO/Produce Building")]
public class ProduceBuildingSO : BuildingSO
{
    [SerializeField]
    List<UnitSO> unitList = new List<UnitSO>();

    public List<UnitSO> UnitList => unitList;
}
