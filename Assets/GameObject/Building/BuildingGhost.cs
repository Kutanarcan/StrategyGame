using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingGhost : MonoBehaviour
{
    [SerializeField]
    Transform buildingGhostSprite;
    [SerializeField]
    Transform placeCheckSprite;

    SpriteRenderer ghostRenderer;
    SpriteRenderer placeCheckRenderer;

    void Awake()
    {
        ghostRenderer = buildingGhostSprite.GetComponent<SpriteRenderer>();
        placeCheckRenderer = placeCheckSprite.GetComponent<SpriteRenderer>();

        Hide();
        BuildingPlacer.OnActiveBuildingChanged += BuildingPlacer_OnActiveBuildingChanged;
    }

    private void BuildingPlacer_OnActiveBuildingChanged(BuildingSO building)
    {
        if (building == null)
            Hide();
        else
            Show(building.Sprite);
    }

    void Update()
    {
        placeCheckRenderer.color = BuildingPlacer.Instance.CanSpawn ? Color.green : Color.red;
        transform.position = new Vector2(Mathf.Round(CustomUtils.GetMouseWorldPosition().x), Mathf.Round(CustomUtils.GetMouseWorldPosition().y));
    }

    void Show(Sprite ghostSprite)
    {
        buildingGhostSprite.gameObject.SetActive(true);
        placeCheckRenderer.gameObject.SetActive(true);
        ghostRenderer.sprite = ghostSprite;
    }

    void Hide()
    {
        buildingGhostSprite.gameObject.SetActive(false);
        placeCheckRenderer.gameObject.SetActive(false);
    }
}
