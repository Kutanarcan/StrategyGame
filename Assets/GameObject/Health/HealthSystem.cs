using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthSystem : MonoBehaviour
{
    public static event System.Action OnDied;
    public static event System.Action OnDamaged;

    [SerializeField]
    HealthSO healthData;

    float currentHealth;

    public float CurrentHealth => currentHealth;

    void OnEnable()
    {
        currentHealth = healthData.MaxHealth;
    }

    public void Damage(float damageAmount)
    {
        currentHealth -= damageAmount;

        currentHealth = Mathf.Clamp(currentHealth, 0, healthData.MaxHealth);

        OnDamaged?.Invoke();

        if (IsDead())
        {
            OnDied?.Invoke();
            GetComponentInParent<PoolableObjectInfo>().Destroy();
        }
    }

    public float HealthAmountNormalized()
    {
        return currentHealth / healthData.MaxHealth;
    }

    public bool IsDead() => currentHealth == 0;
}
