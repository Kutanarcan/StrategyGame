using UnityEngine;

[CreateAssetMenu(fileName = "Health", menuName = "ScriptableObjects/HealthSO")]
public class HealthSO : ScriptableObject
{
    [SerializeField]
    float maxHealth;

    public float MaxHealth => maxHealth;
}
