using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Enemy : Character
{
    private Rigidbody2D _body;

    // Start is called before the first frame update
    new void Start()
    {
        base.Start();
        StartCoroutine(AttackCycle());
        _body = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
    }

    IEnumerator AttackCycle() 
    {
        Weapon weapon = GetWeapon();
        WaitForSeconds wait = new WaitForSeconds(5F);
 
        while (true) {
            weapon.Attack(moveset.GetAttack(AttackDirection.UP));
            yield return wait;
        }
    } 

    public override void AddDamageKnockback(Vector2 vector) {
        _body.velocity += vector;
    }
}
