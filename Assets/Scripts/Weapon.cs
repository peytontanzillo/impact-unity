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
    private bool hasLoaded = false;

    // Start is called before the first frame update
    void Start()
    {
        belongsTo = transform.parent.GetComponent<Character>();
        _animator = GetComponent<Animator>();
        hasLoaded = true;
    }

    // Update is called once per frame
    void Update()
    {
        //UpdateCurrentAttack();
    }

    public void Attack( MeleeAttack attack, bool isBackwards = false) {
        currentAttack = attack;
        this.isBackwards = isBackwards;
        attack.ExecuteAttack(_animator);
    }

    public void FinishAttack() {
        currentAttack = null;
    }

    public bool IsAttacking() {
        return currentAttack != null;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        Character character = other.gameObject.GetComponent<Character>();
        if (character != null && character != belongsTo && !charactersHit.Contains(character) && hasLoaded) { 
            character.TakeDamage(currentAttack, isBackwards);
        }
    }
}
