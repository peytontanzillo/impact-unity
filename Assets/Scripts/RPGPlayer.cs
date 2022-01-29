using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class RPGPlayer : MonoBehaviour
{
    private Rigidbody2D body;
    public float moveSpeed = 10.0F;
    private Dictionary<KeyCode, Vector2> directions = new Dictionary<KeyCode, Vector2>(){ 
        { KeyCode.UpArrow, new Vector2(0, 1) },
        { KeyCode.DownArrow, new Vector2(0, -1) },
        { KeyCode.RightArrow, new Vector2(1, 0) },
        { KeyCode.LeftArrow, new Vector2(-1, 0) },
    };
    // Start is called before the first frame update
    void Start()
    {
        body = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        body.velocity = SetPlayerVelocity();
    }

    Vector2 SetPlayerVelocity() {
        KeyCode[] heldDirections = directions.Keys.Where(dxn => Input.GetKey(dxn)).ToArray();
        if (heldDirections.Count() != 1) { return new Vector2(0, 0); }
        return directions[heldDirections[0]] * new Vector2(moveSpeed, moveSpeed);
    }
}
