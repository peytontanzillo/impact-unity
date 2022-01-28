using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileAttack : Attack
{
    string projectilePath;
    string explosionPath;
    public ProjectileAttack(string animation, float damage, Vector2 knockback, string projectilePath, string explosionPath = "") : base(animation, damage, knockback) 
    {
        this.projectilePath = projectilePath;
        this.explosionPath = explosionPath;
    }

    public void ExecuteAttack(Character character, bool isBackwards) {
        GameObject gameObject = Object.Instantiate(Resources.Load(projectilePath) as GameObject, character.gameObject.transform.position, Quaternion.identity);
        Projectile projectile = gameObject.GetComponent<Projectile>();
        projectile.Attack(character, this, isBackwards, explosionPath);
    }
}