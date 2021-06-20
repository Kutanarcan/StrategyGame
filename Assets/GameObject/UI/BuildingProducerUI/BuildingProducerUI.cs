using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class BuildingProducerUI : MonoBehaviour
{
    [SerializeField]
    ProducePanel produceUnitPanel;

    [Header("Building Data")]
    [SerializeField]
    TextMeshProUGUI buildingName;
    [SerializeField]
    Image buildingIcon;

    Canvas myCanvas;

    void Awake()
    {
        myCanvas = GetComponent<Canvas>();
        InitPanels();

        Building.OnBuildingSelectionChanged += Building_OnBuildingSelectionChanged;
    }

    void InitPanels()
    {
        myCanvas.enabled = false;
        produceUnitPanel.gameObject.SetActive(false);
    }

    void Building_OnBuildingSelectionChanged(Building selectedBuilding)
    {
        if (selectedBuilding == null)
        {
            myCanvas.enabled = false;
            return;
        }

        myCanvas.enabled = true;

        BuildingSO buildingData = selectedBuilding.BuildingTypeHolder.BuildingData;

        SetupProducePanelData(buildingData);

        ICanProduce produceBuilding = selectedBuilding.GetComponent<ICanProduce>();

        if (produceBuilding != null)
        {
            produceUnitPanel.gameObject.SetActive(true);

            var buildingUnitList = produceBuilding.GetProduceSO().UnitList;
            produceUnitPanel.OrganizeProducePanel(buildingUnitList, produceBuilding);
        }
        else
            produceUnitPanel.gameObject.SetActive(false);
    }

    void SetupProducePanelData(BuildingSO buildingData)
    {
        buildingName.SetText(buildingData.BuildingName);
        buildingIcon.sprite = buildingData.Sprite;
    }
}
