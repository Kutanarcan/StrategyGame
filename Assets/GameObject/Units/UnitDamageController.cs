using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitDamageController : MonoBehaviour, IDamageable
{
    HealthSystem healthSystem;

    void Awake()
    {
        healthSystem = GetComponent<HealthSystem>();
    }

    public void Damage(float damageAmount)
    {
        healthSystem.Damage(damageAmount);
    }
}
