using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingDamageController : MonoBehaviour, IDamageable
{
    [SerializeField]
    SpriteRenderer buildingGFXRenderer;

    Color defaultColor;
    HealthSystem healthSystem;
    Coroutine damageEffectCoroutine;
    WaitForSeconds damageEffectWaitSeconds;

    const float DAMAGE_EFFECT_SECONDS = 0.2F;

    void Awake()
    {
        healthSystem = GetComponent<HealthSystem>();
        damageEffectWaitSeconds = new WaitForSeconds(DAMAGE_EFFECT_SECONDS);
        defaultColor = buildingGFXRenderer.color;
    }

    public void Damage(float damageAmount)
    {
        healthSystem.Damage(damageAmount);

        if (!healthSystem.IsDead())
        {
            damageEffectCoroutine = damageEffectCoroutine = StartCoroutine(DamageEffectCoroutine());
        }
    }

    IEnumerator DamageEffectCoroutine()
    {
        buildingGFXRenderer.color = Color.red;
        yield return damageEffectWaitSeconds;
        buildingGFXRenderer.color = defaultColor;
    }

}
