using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Character
{
    public float jumpForce = 6.0f;
    public int maxJumps = 2;
    public float maxSpeed = 10; //This is the maximum speed that the object will achieve
    public float acceleration = 10;//How fast will object reach a maximum speed
    public float deceleration = 10;//How fast will object reach a speed of 0
    private float speed = 0;//Don't touch this
    private Rigidbody2D _body;
    private BoxCollider2D _collider;
    
    private int _jumps;
    private bool _previouslyGrounded = false;

    // Start is called before the first frame update
    new void Start()
    {
        base.Start();
        _collider = GetComponent<BoxCollider2D>();
        _body = GetComponent<Rigidbody2D>();
        _jumps = 0; 
        Physics2D.IgnoreCollision(_collider, GameObject.Find("Enemy").GetComponent<Collider2D>());
    }

    // Update is called once per frame
    void Update()
    {
        HorizontalMovement();
        Jump();
        PlayerAttack(this.transform.localScale.x < 0);
    }

    private bool ShouldResetJumps() {
        Vector3 max = _collider.bounds.max;
        Vector3 min = _collider.bounds.min;
        Vector2 corner1 = new Vector2(max.x, min.y - .1f);    
        Vector2 corner2 = new Vector2(min.x, min.y - .2f);    
        Collider2D hit = Physics2D.OverlapArea(corner1, corner2);
        bool grounded = hit != null && hit.gameObject.tag == "Ground";

        // The jumps should only reset when the player was not previously grounded
        if (grounded && _previouslyGrounded) return false;
        _previouslyGrounded = grounded;
        return grounded;
    }

    private void HorizontalMovement() {
        if ((Input.GetKey(KeyCode.LeftArrow)) && (speed > -maxSpeed)) {
            speed -= acceleration * Time.deltaTime;
        } else if ((Input.GetKey(KeyCode.RightArrow)) && (speed < maxSpeed)) {
            speed += acceleration * Time.deltaTime;
        } else if(speed > deceleration * Time.deltaTime) {
            speed -= deceleration * Time.deltaTime;
        } else if(speed < -deceleration * Time.deltaTime) {
            speed += deceleration * Time.deltaTime;
        } else {
            speed = 0;
        }
        HandleSpriteDirection();
        _body.velocity = new Vector2(speed, _body.velocity.y);
    }

    private void HandleSpriteDirection() {
        if ((speed < 0 && this.transform.localScale.x < 0) || (speed > 0 && this.transform.localScale.x > 0)) {
            Weapon weapon = GetWeapon();
            if (!weapon.IsAttacking()) {
                this.transform.localScale = new Vector2(-transform.localScale.x, transform.localScale.y);
            }
        }
    }

    private void Jump() {
        if (ShouldResetJumps()) _jumps = maxJumps;
        if (_jumps == 0) return;

        if (Input.GetKeyDown(KeyCode.UpArrow)) {    
            Vector2 jump = new Vector2(_body.velocity.x, jumpForce);    
            _body.velocity = jump;
            _jumps -= 1;
        }
    }

    private void PlayerAttack(bool isBackwards) {
        if (Input.GetKeyDown(KeyCode.Space)) { 
            Weapon weapon = GetWeapon();
            if ((Input.GetKey(KeyCode.RightArrow) && !isBackwards) || (Input.GetKey(KeyCode.LeftArrow) && isBackwards)) {
                weapon.Attack("Attack_Back");
            } else {
                weapon.Attack("Attack_Front");
            }
        }
    }

    public override void AddDamageKnockback(Vector2 vector) {
        _body.velocity += vector;
        speed += vector.x;
    }
}
