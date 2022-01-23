using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    private Animator _animator;
    private string attackState;
    // Prevents case where 1 attack can hit enemies twice
    private List<Character> charactersHit = new List<Character>();
    Character belongsTo;

    // Start is called before the first frame update
    void Start()
    {
        _animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        UpdateAttackState();
    }

    public void Attack( string attack ) {
        attackState = attack;
        _animator.Play(attackState);
    }

    private void UpdateAttackState() {
        if (attackState != "Idle" && _animator.GetCurrentAnimatorStateInfo(0).IsName("Idle"))
        {
            attackState = "Idle";
            charactersHit.Clear();
        }
    }

    public bool IsAttacking() {
        return attackState != "Idle";
    }

    public void SetBelongsTo(Character character) {
        belongsTo = character;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        Character character = other.gameObject.GetComponent<Character>();
        if (character != null && character != belongsTo && !charactersHit.Contains(character)) { 
            character.TakeDamage(attackState, other.gameObject);
        }
    }
}
