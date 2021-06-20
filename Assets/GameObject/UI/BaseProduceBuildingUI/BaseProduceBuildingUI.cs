using UnityEngine;
using UnityEngine.UI;

public class BaseProduceBuildingUI : MonoBehaviour
{
    [SerializeField]
    GameObject producePanel;
    [SerializeField]
    BuildingListSO buildingList;

    public static event System.Action<BuildingSO> OnBuildingButtonClicked;

    BuildingTemplateUI buildingTemplate;

    void Awake()
    {
        InitBuildingPanel();
    }

    void InitBuildingPanel()
    {
        buildingTemplate = GetComponentInChildren<BuildingTemplateUI>();
        buildingTemplate.gameObject.SetActive(false);

        for (int i = 0; i < buildingList.Buildings.Count; i++)
        {
            var currentBuildingData = buildingList.Buildings[i];
            var tmpBuildingTemp = Instantiate(buildingTemplate, producePanel.transform);
            
            tmpBuildingTemp.gameObject.SetActive(true);
            tmpBuildingTemp.BuildingName.SetText(currentBuildingData.BuildingName);
            tmpBuildingTemp.BuildingIcon.sprite = currentBuildingData.Sprite;
            tmpBuildingTemp.BuildingButton.onClick.AddListener(() =>
            {
                OnBuildingButtonClicked?.Invoke(currentBuildingData);
            });


        }
    }
}
