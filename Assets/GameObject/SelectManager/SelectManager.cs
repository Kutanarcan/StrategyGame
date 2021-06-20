using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class SelectManager : MonoBehaviour
{
    ISelectItem selectedItem;

    void Update()
    {
        if (Input.GetMouseButtonDown(0) && !EventSystem.current.IsPointerOverGameObject() && BuildingPlacer.Instance.ActiveBuilding == null)
            SelectItem();
    }

    void SelectItem()
    {
        ISelectItem item = null;

        RaycastHit2D raycastHit2D = Physics2D.Raycast(CustomUtils.GetMouseWorldPosition(), Vector3.forward);

        if (raycastHit2D.collider)
            item = raycastHit2D.collider.GetComponent<ISelectItem>();

        if (item == null && selectedItem != null)
        {
            selectedItem.DeSelect();
            selectedItem = null;
        }
        else if (item != null && selectedItem != null)
        {
            selectedItem.DeSelect();
            selectedItem = item;
            item.Select();
        }
        else if (item != null)
        {
            selectedItem = item;
            item.Select();
        }
    }
}
