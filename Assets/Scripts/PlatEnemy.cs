using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class PlatEnemy : PlatCharacter
{
    private Rigidbody2D _body;
    public float attackTime = 5F;
    public AttackDirection attackDirection = AttackDirection.NEUTRAL;
    Attack attack;


    // Start is called before the first frame update
    new void Start()
    {
        base.Start();
        StartCoroutine(AttackCycle());
        _body = GetComponent<Rigidbody2D>();
        attack = moveset.GetAttack(attackDirection);
    }

    // Update is called once per frame
    void Update()
    {
    }

    IEnumerator AttackCycle() 
    {
        WaitForSeconds wait = new WaitForSeconds(attackTime);
 
        while (true) {
            switch(attack) {
                case MeleeAttack meleeAttack:
                    weapon.Attack(meleeAttack, true);
                    break;
                case ProjectileAttack projectileAttack:
                    projectileAttack.ExecuteAttack(this, true);
                    break; 
            }
            yield return wait;
        }
    } 

    public override void AddDamageKnockback(Vector2 vector) {
        _body.velocity += vector;
    }
}
