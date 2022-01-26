using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileAttack : Attack
{
    string projectilePath;
    public ProjectileAttack(string animation, float damage, Vector2 knockback, string projectilePath, float projectileSpeed) : base(animation, damage, knockback) 
    {
        this.projectilePath = projectilePath;
    }

    public void ExecuteAttack(Character character, bool isBackwards) {
        GameObject gameObject = Object.Instantiate(Resources.Load(projectilePath) as GameObject, character.gameObject.transform.position, Quaternion.identity);
        Projectile projectile = gameObject.GetComponent<Projectile>();
        projectile.Attack(character, this, isBackwards);
    }
}