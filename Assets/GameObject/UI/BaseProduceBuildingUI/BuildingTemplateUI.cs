using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class BuildingTemplateUI : MonoBehaviour
{
    [SerializeField]
    TextMeshProUGUI buildingName;
    [SerializeField]
    Image buildingIcon;
    [SerializeField]
    Button buildingButton;

    public TextMeshProUGUI BuildingName => buildingName;
    public Image BuildingIcon => buildingIcon;
    public Button BuildingButton => buildingButton;
}
