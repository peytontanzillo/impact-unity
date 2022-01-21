using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    private Animator _animator;
    private Enemy enemy;

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
                _animator.Play("Attack_Left");
            } else {
                _animator.Play("Attack_Right");
            }
                
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Enemy")
        {
            other.gameObject.GetComponent<Enemy>().TakeDamage();
        }
    }
}
