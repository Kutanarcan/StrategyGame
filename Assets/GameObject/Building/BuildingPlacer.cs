using UnityEngine;
using UnityEngine.EventSystems;

public class BuildingPlacer : MonoBehaviour
{
    public static BuildingPlacer Instance { get; private set; }

    public bool CanSpawn
    {
        get
        {
            if (activeBuilding == null)
                return false;
            else
                return CanSpawnBuilding(activeBuilding, CustomUtils.GetMouseWorldPositionFixed(), out string errorMessage);
        }
    }

    public static event System.Action<BuildingSO> OnActiveBuildingChanged;
    public BuildingSO ActiveBuilding => activeBuilding;
    BuildingSO activeBuilding;
    BuildingFactory buildingFactory;

    void Awake()
    {
        BaseProduceBuildingUI.OnBuildingButtonClicked += SetActiveBuilding;
        buildingFactory = new BuildingFactory();
        Instance = this;
    }

    void Update()
    {
        if (activeBuilding != null && Input.GetMouseButtonDown(0) && !EventSystem.current.IsPointerOverGameObject())
        {
            if (CanSpawnBuilding(activeBuilding, CustomUtils.GetMouseWorldPositionFixed(), out string errorMessage))
            {
                Create();
            }
        }

        if (Input.GetMouseButtonDown(1))
            SetActiveBuilding(null);
    }

    public void SetActiveBuilding(BuildingSO building)
    {
        activeBuilding = building;
        OnActiveBuildingChanged?.Invoke(activeBuilding);
    }

    void OnDisable()
    {
        BaseProduceBuildingUI.OnBuildingButtonClicked -= SetActiveBuilding;
    }

    public void Create()
    {
        var currentBuilding = buildingFactory.GetInstance(activeBuilding);
        currentBuilding.transform.position = new Vector2(Mathf.Round(CustomUtils.GetMouseWorldPosition().x), Mathf.Round(CustomUtils.GetMouseWorldPosition().y));
        PathFinderScanner.Instance.Scan();
    }


    public bool CanSpawnBuilding(BuildingSO buildingType, Vector3 position, out string errorMessage)
    {
        errorMessage = "Placed";

        BoxCollider2D boxCollider2D = buildingType.Prefab.GetComponent<BoxCollider2D>();

        Collider2D[] collider2DArrays = Physics2D.OverlapBoxAll(position + (Vector3)boxCollider2D.offset, boxCollider2D.size/*buildingType.Prefab.transform.localScale*/, 0);

        foreach (var item in collider2DArrays)
        {
            if (item.GetComponent<ISelectItem>() != null)
            {
                errorMessage = "Area Is Not Clear!";
                return false;
            }
        }

        return true;
    }
}
