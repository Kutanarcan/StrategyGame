using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Building : MonoBehaviour, ISelectItem
{
    public static event System.Action<Building> OnBuildingSelectionChanged;

    [SerializeField]
    GameObject healthBar;

    public BuildingTypeHolder BuildingTypeHolder => buildingTypeHolder;

    protected bool isSelected;

    BuildingTypeHolder buildingTypeHolder;

    protected virtual void Awake()
    {
        buildingTypeHolder = GetComponent<BuildingTypeHolder>();
        healthBar.SetActive(false);
    }

    void OnDisable()
    {
        if (isSelected)
            DeSelect();
    }

    public virtual void Select()
    {
        CursorManager.Instance.SetActiveCursorData(buildingTypeHolder.BuildingData.CursorData);
        healthBar.SetActive(true);
        OnBuildingSelectionChanged?.Invoke(this);
        isSelected = true;
    }

    public virtual void DeSelect()
    {
        CursorManager.Instance.ResetActiveCursorData();
        healthBar.SetActive(false);
        OnBuildingSelectionChanged?.Invoke(null);
        isSelected = false;
    }
}
