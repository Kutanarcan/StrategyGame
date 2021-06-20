using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProducePanel : MonoBehaviour
{
    [SerializeField]
    UnitTemplate unitTemplate;

    const int STARTING_UNIT_TEMPLATE_COUNT = 10;

    void Awake()
    {
        InitUnitTemplates();
    }

    public void OrganizeProducePanel(List<UnitSO> buildingUnitList, ICanProduce produceBuilding)
    {
        DeActivateChilds();

        for (int i = 0; i < buildingUnitList.Count; i++)
        {
            UnitTemplate currentUnitTemplate = transform.GetChild(i).GetComponent<UnitTemplate>();
            currentUnitTemplate.SetupTemplate(buildingUnitList[i], produceBuilding);
        }
    }

    void DeActivateChilds()
    {
        for (int i = 0; i < transform.childCount; i++)
        {
            var child = transform.GetChild(i);
            child.gameObject.SetActive(false);
        }
    }

    void InitUnitTemplates()
    {
        unitTemplate.gameObject.SetActive(false);

        for (int i = 0; i < STARTING_UNIT_TEMPLATE_COUNT; i++)
        {
            Instantiate(unitTemplate, transform);
        }
    }
}
