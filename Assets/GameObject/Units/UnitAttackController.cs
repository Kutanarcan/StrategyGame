using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitAttackController : MonoBehaviour
{
    IDamageable target;

    public IDamageable Target => target;

    Coroutine attackCoroutine;
    Base_Unit base_Unit;
    float attackCounter;
    bool isAttacking;
    Vector2 attackDirection;

    void Awake()
    {
        base_Unit = GetComponent<Base_Unit>();
    }

    public void FindTarget()
    {
        RaycastHit2D hitInfo = Physics2D.Raycast(CustomUtils.GetMouseWorldPosition(), Vector3.forward);

        target = hitInfo.collider ? hitInfo.collider.GetComponent<IDamageable>() : null;

        if (target == null && hitInfo.collider)
        {
            base_Unit.SetDestination(hitInfo.collider.gameObject.transform);
        }

        bool isAttackingSelf = target == GetComponent<IDamageable>();

        ResetValues();

        if (target != null && !isAttackingSelf)
        {
            attackDirection = (hitInfo.collider.transform.position - transform.position).normalized;
            attackCoroutine = StartCoroutine(AttackCoroutine(hitInfo.collider.gameObject));
        }
    }

    IEnumerator AttackCoroutine(GameObject attackObject)
    {
        Vector3 destination = attackObject.transform.position;
        base_Unit.SetDestination(attackObject.transform);
        base_Unit.HandleAnimationSettings(true, destination);

        while (true)
        {
            if (Vector2.Distance(transform.position, destination) > base_Unit.UnitData.AttackRange)
            {
                base_Unit.Move(destination);
            }

            if (!isAttacking && Vector2.Distance(transform.position, destination) < base_Unit.UnitData.AttackRange)
            {
                base_Unit.SetDestination(transform);
                base_Unit.UnitAnimationController.IsAttacking = true;
                base_Unit.UnitAnimationController.IsWalking = false;
                isAttacking = true;
            }

            if (isAttacking)
                Attack(attackObject);

            yield return null;
        }
    }

    void Attack(GameObject attackObject)
    {
        attackCounter -= Time.deltaTime;

        if (attackCounter <= 0.05f)
        {
            attackCounter = base_Unit.UnitData.FireSpeed;

            RaycastHit2D hitInfo = Physics2D.Raycast(transform.position, attackDirection);

            if (hitInfo.collider != null && hitInfo.collider.GetComponent<IDamageable>() != null)
            {
                if (attackObject.activeInHierarchy)
                    target.Damage(base_Unit.UnitData.DamageAmount);
                else
                    ResetValues();
            }
        }
    }

    void StopAttackCoroutine()
    {
        if (attackCoroutine != null)
        {
            StopCoroutine(attackCoroutine);
            attackCoroutine = null;
        }
    }

    void ResetValues()
    {
        base_Unit.UnitAnimationController.IsAttacking = false;
        isAttacking = false;
        attackCounter = 0;
        StopAttackCoroutine();
    }
}
