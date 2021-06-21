using UnityEngine;
using Pathfinding;

public class Base_Unit : MonoBehaviour, ISelectItem
{
    [SerializeField]
    UnitSO unitData;
    [SerializeField]
    GameObject healthBar;
    [SerializeField]
    float movementSpeed = 20f;

    public UnitSO UnitData => unitData;
    public UnitAnimationController UnitAnimationController => unitAnimationController;

    Rigidbody2D body;
    bool isSelected;
    UnitAnimationController unitAnimationController;
    UnitAttackController unitAttackController;
    AIDestinationSetter destinationSetter;

    Transform destination;

    void Awake()
    {
        unitAnimationController = GetComponent<UnitAnimationController>();
        unitAttackController = GetComponent<UnitAttackController>();
        destinationSetter = GetComponent<AIDestinationSetter>();
        body = GetComponent<Rigidbody2D>();

        healthBar.SetActive(false);
    }

    public void Select()
    {
        CursorManager.Instance.SetActiveCursorData(unitData.CursorData);
        healthBar.SetActive(true);
        isSelected = true;
    }

    public void DeSelect()
    {
        CursorManager.Instance.ResetActiveCursorData();
        healthBar.SetActive(false);
        isSelected = false;
    }

    void OnDisable()
    {
        if (isSelected)
            DeSelect();
    }

    void Update()
    {
        if (isSelected && Input.GetMouseButtonDown(1))
        {
            unitAttackController.FindTarget();
        }

        if (unitAttackController.Target == null && destination != null && Vector2.Distance(transform.position, destination.position) > 0.1f)
        {
            if (Vector2.Distance(transform.position, destination.position) < 0.2f)
            {
                HandleAnimationSettings(false, destination.position);
                SetDestination(null);
            }
        }
    }

    public void Move(Vector3 destination)
    {
        body.MovePosition(Vector2.MoveTowards(body.position, destination, movementSpeed * Time.deltaTime));
    }

    public void HandleAnimationSettings(bool isWalking, Vector3 destination)
    {
        Vector2 direction = (destination - transform.position).normalized;
        unitAnimationController.IsWalking = isWalking;
        unitAnimationController.Horizontal = direction.x;
        unitAnimationController.Vertical = direction.y;
    }

    public void SetDestination(Transform destination)
    {
        this.destination = destination;
        destinationSetter.target = destination;

        if (destination)
            HandleAnimationSettings(true, destination.position);
    }
}
