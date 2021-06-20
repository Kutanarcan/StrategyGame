using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitAnimationController : MonoBehaviour
{
    [SerializeField]
    Animator anim;

    static int paramHorizontal = Animator.StringToHash("Horizontal");
    static int paramVertical = Animator.StringToHash("Vertical");
    static int paramIsWalking = Animator.StringToHash("IsWalking");
    static int paramIsAttacking = Animator.StringToHash("IsAttacking");

    public float Horizontal
    {
        get => anim.GetFloat(paramHorizontal);

        set => anim.SetFloat(paramHorizontal, value);
    }

    public float Vertical
    {
        get => anim.GetFloat(paramVertical);

        set => anim.SetFloat(paramVertical, value);
    }

    public bool IsWalking
    {
        get => anim.GetBool(paramIsWalking);

        set => anim.SetBool(paramIsWalking, value);
    }

    public bool IsAttacking
    {
        get => anim.GetBool(paramIsAttacking);

        set => anim.SetBool(paramIsAttacking, value);
    }
}
