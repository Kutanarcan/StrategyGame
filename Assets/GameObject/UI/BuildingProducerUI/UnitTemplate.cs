using UnityEngine;
using UnityEngine.UI;

public class UnitTemplate : MonoBehaviour
{
    [SerializeField]
    Image unitIcon;
    [SerializeField]
    Button unitButton;

    public void SetupTemplate(UnitSO unitData, ICanProduce produceBuilding)
    {
        unitButton.onClick.RemoveAllListeners();

        unitIcon.sprite = unitData.Icon;
        gameObject.SetActive(true);
        unitButton.onClick.AddListener(() =>
        {
            produceBuilding.Produce(unitData);
        });
    }
}
