using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float jumpForce = 6.0f;
    public float speed = 2000.0f;
    public int maxJumps = 2;

    private Rigidbody2D _body;
    private BoxCollider2D _collider;
    
    private int _jumps;
    private bool _previouslyGrounded = false;

    // Start is called before the first frame update
    void Start()
    {
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
        float deltaX = Input.GetAxis("Horizontal") * speed * Time.deltaTime;
        Vector2 movement = new Vector2(deltaX, _body.velocity.y);    
        _body.velocity = movement;
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
}
