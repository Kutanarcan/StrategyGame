using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    [SerializeField]
    Image healthBar;

    HealthSystem healthSystem;

    void Awake()
    {
        healthSystem = GetComponentInParent<HealthSystem>();
    }

    void OnEnable()
    {
        HealthSystem.OnDamaged += UpdateHealthBar;
        UpdateHealthBar();
    }

    void OnDisable()
    {
        HealthSystem.OnDamaged -= UpdateHealthBar;
    }

    private void UpdateHealthBar()
    {
        healthBar.fillAmount = healthSystem.HealthAmountNormalized();
    }
}
