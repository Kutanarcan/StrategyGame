using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Unit", menuName = "UnitSO/Unit")]
public class UnitSO : ScriptableObject
{
    [SerializeField]
    string unitName;
    [SerializeField]
    Base_Unit prefab;
    [SerializeField]
    Sprite icon;

    [Header("Attack Data")]
    [SerializeField]
    float damageAmount;
    [SerializeField]
    float attackRange;
    [SerializeField]
    float fireSpeed;
    [SerializeField]
    CursorSO cursorData;

    public string UnitName => unitName;
    public Base_Unit Prefab => prefab;
    public Sprite Icon => icon;
    public float DamageAmount => damageAmount;
    public float AttackRange => attackRange;
    public float FireSpeed => fireSpeed;
    public CursorSO CursorData => cursorData;

}
