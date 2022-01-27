using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{

    Character firedFrom;
    ProjectileAttack projectileAttack;
    bool isBackwards;
    public float projectileSpeed;

    public void Attack(Character firedFrom, ProjectileAttack projectileAttack, bool isBackwards) {
        this.firedFrom = firedFrom;
        this.projectileAttack = projectileAttack;
        this.isBackwards = isBackwards;
        GetComponent<Rigidbody2D>().velocity = new Vector2((isBackwards ? -1 : 1) * projectileSpeed, 0);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        Character character = other.gameObject.GetComponent<Character>();
        if (character != null && character != firedFrom) { 
            Destroy(gameObject);
            character.TakeDamage(projectileAttack, isBackwards);
        }
    }
}
