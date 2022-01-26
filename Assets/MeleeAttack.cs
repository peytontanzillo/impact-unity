using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeAttack : Attack
{
    public MeleeAttack(string animation, float damage, Vector2 knockback) : base(animation, damage, knockback) {}

    public void ExecuteAttack(Animator animator) {
        animator.Play(this.animation);
    }
}