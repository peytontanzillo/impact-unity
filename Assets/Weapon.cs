using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    private Animator _animator;
    private string attackState;
    // Prevents case where 1 attack can hit enemies twice
    private List<Enemy> enemiesHitOnAttack = new List<Enemy>();

    // Start is called before the first frame update
    void Start()
    {
        _animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        Attack();
    }

    private void Attack() {
        if (Input.GetKeyDown(KeyCode.Space)) {   
            if (Input.GetKey(KeyCode.LeftArrow)) {
                attackState = "Attack_Left";
            } else {
                attackState = "Attack_Right";
            }
            _animator.Play(attackState);
        }
    }

    private void UpdateAttackState() {
        if (attackState != "Idle" && _animator.GetCurrentAnimatorStateInfo(0).IsName("Idle"))
        {
            attackState = "Idle";
            enemiesHitOnAttack.Clear();
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Enemy")
        {
            Enemy enemy = other.gameObject.GetComponent<Enemy>();
            if (!enemiesHitOnAttack.Contains(enemy)) {
                enemy.TakeDamage(attackState);
            }
        }
    }
}
