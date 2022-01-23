using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    private Animator _animator;
    private Attack currentAttack;
    // Prevents case where 1 attack can hit enemies twice
    private bool isBackwards = false;
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
        UpdateCurrentAttack();
    }

    public void Attack( Attack attack, bool isBackwards = false) {
        currentAttack = attack;
        this.isBackwards = isBackwards;
        _animator.Play(currentAttack.animation);
    }

    private void UpdateCurrentAttack() {
        if (currentAttack != null && _animator.GetCurrentAnimatorStateInfo(0).IsName("Idle"))
        {
            currentAttack = null;
            charactersHit.Clear();
        }
    }

    public bool IsAttacking() {
        return currentAttack != null;
    }

    public void SetBelongsTo(Character character) {
        belongsTo = character;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        Character character = other.gameObject.GetComponent<Character>();
        if (character != null && character != belongsTo && !charactersHit.Contains(character)) { 
            character.TakeDamage(currentAttack, other.gameObject, isBackwards);
        }
    }
}
