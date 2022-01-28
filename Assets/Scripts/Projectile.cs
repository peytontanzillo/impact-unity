using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{

    Character firedFrom;
    ProjectileAttack projectileAttack;
    bool isBackwards;
    #nullable enable
    GameObject? explosion;
    #nullable disable
    public float speed;
    public float launchHeight = 0.0F;


    public void Attack(Character firedFrom, ProjectileAttack projectileAttack, bool isBackwards, string explosionPath) {
        this.firedFrom = firedFrom;
        this.projectileAttack = projectileAttack;
        this.isBackwards = isBackwards;
        this.explosion = explosionPath == "" ? null : Resources.Load(explosionPath) as GameObject;
        GetComponent<Rigidbody2D>().velocity = new Vector2((isBackwards ? -1 : 1) * speed, launchHeight);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        Character character = other.gameObject.GetComponent<Character>();
        if (character != null && character != firedFrom) { 
            Destroy(gameObject);
            if (explosion != null) {
                Instantiate(explosion, gameObject.transform.position, Quaternion.identity);
            }
            character.TakeDamage(projectileAttack, isBackwards);
        }

        if (other.gameObject.tag == "Ground") {
            Destroy(gameObject);
            if (explosion != null) {
                Instantiate(explosion, gameObject.transform.position, Quaternion.identity);
            }
        }
    }
}
