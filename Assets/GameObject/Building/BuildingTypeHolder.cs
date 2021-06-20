using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingTypeHolder : MonoBehaviour
{
    [SerializeField]
    BuildingSO buildingData;

    public BuildingSO BuildingData => buildingData;
}
