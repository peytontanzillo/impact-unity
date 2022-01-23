using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack
{
    public string animation;
    public float damage;
    public Vector2 knockback;
    public Attack(string animation, float damage, Vector2 knockback) {
        this.animation = animation;
        this.damage = damage;
        this.knockback = knockback;
    }
}
