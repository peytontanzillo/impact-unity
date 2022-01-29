using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    private Animator _animator;
    private Attack currentAttack;
    // Prevents case where 1 attack can hit enemies twice
    private bool isBackwards = false;
    private List<PlatCharacter> charactersHit = new List<PlatCharacter>();
    PlatCharacter belongsTo;
    private bool hasLoaded = false;

    // Start is called before the first frame update
    void Start()
    {
        belongsTo = transform.parent.GetComponent<PlatCharacter>();
        _animator = GetComponent<Animator>();
        hasLoaded = true;
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void Attack( MeleeAttack attack, bool isBackwards = false) {
        currentAttack = attack;
        this.isBackwards = isBackwards;
        attack.ExecuteAttack(_animator);
    }

    public void FinishAttack() {
        currentAttack = null;
        charactersHit.Clear();
    }

    public bool IsAttacking() {
        return currentAttack != null;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        PlatCharacter character = other.gameObject.GetComponent<PlatCharacter>();
        if (character != null && character != belongsTo && !charactersHit.Contains(character) && hasLoaded) { 
            character.TakeDamage(currentAttack, isBackwards);
            charactersHit.Add(character);
        }
    }
}
