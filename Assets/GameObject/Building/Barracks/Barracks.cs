using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Barracks : Building, ICanProduce
{
    [SerializeField]
    Transform spawnPoint;

    bool isSelected;

    protected override void Awake()
    {
        base.Awake();
        spawnPoint.gameObject.SetActive(false);
    }

    public override void Select()
    {
        base.Select();
        isSelected = true;
        spawnPoint.gameObject.SetActive(true);
    }

    public override void DeSelect()
    {
        base.DeSelect();
        isSelected = false;
        spawnPoint.gameObject.SetActive(false);
    }

    void Update()
    {
        if (isSelected && Input.GetMouseButtonDown(1))
        {
            spawnPoint.position = CustomUtils.GetMouseWorldPosition();
        }
    }

    public void Produce(UnitSO unit)
    {
        var tmpUnit = ObjectPooler.Instance.SpawnPoolObject(unit.Prefab, transform.position + Vector3.down * 2f, Quaternion.identity);
        RaycastHit2D hitInfo = Physics2D.Raycast(spawnPoint.position, Vector3.forward);
        tmpUnit.SetDestination(hitInfo.collider.transform);
    }

    public ProduceBuildingSO GetProduceSO()
    {
        return (ProduceBuildingSO)BuildingTypeHolder.BuildingData;
    }
}
