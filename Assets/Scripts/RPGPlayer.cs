using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class RPGPlayer : MonoBehaviour
{
    public Sprite upSprite, downSprite, leftSprite, rightSprite = null;
    private class DirectionData {
        public Vector2 direction;
        public Sprite sprite;
        public DirectionData(Vector2 direction, Sprite sprite) {
            this.direction = direction;
            this.sprite = sprite;
        }
    }
    private Rigidbody2D body;
    private SpriteRenderer spriteRenderer;
    public float moveSpeed = 10.0F;
    public NPC talkingTo;

    private DirectionData directionData;
    private Dictionary<KeyCode, DirectionData> directions = new Dictionary<KeyCode, DirectionData>();
    // Start is called before the first frame update
    void Start()
    {
        body = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        directions.Add(KeyCode.UpArrow, new DirectionData(new Vector2(0, 1), upSprite));
        directions.Add(KeyCode.DownArrow, new DirectionData(new Vector2(0, -1), downSprite));
        directions.Add(KeyCode.RightArrow, new DirectionData(new Vector2(1, 0), rightSprite));
        directions.Add(KeyCode.LeftArrow, new DirectionData(new Vector2(-1, 0), leftSprite));
    }

    // Update is called once per frame
    void Update()
    {
        SetPlayerVelocity();
        NPCInteract();
    }

    void SetPlayerVelocity() {
        KeyCode[] heldDirections = directions.Keys.Where(dxn => Input.GetKey(dxn)).ToArray();
        if (talkingTo != null || heldDirections.Count() != 1) { 
            body.velocity = new Vector2(0, 0);
            return; 
        }
        directionData = directions[heldDirections[0]];
        body.velocity = directionData.direction * new Vector2(moveSpeed, moveSpeed);
        spriteRenderer.sprite = directionData.sprite;
    }

    void NPCInteract() {
        if (Input.GetKeyDown(KeyCode.Space)) {
            if (talkingTo) {
                talkingTo.ContinueConversation();
            } else {
                RaycastHit2D hit = Physics2D.Raycast(transform.position, directionData.direction, 3.0F);
                if (hit.collider != null) {
                    NPC npc = hit.collider.GetComponent<NPC>();
                    if (npc != null) {
                        talkingTo = npc;
                        npc.StartConversation(this);
                    }
                }
            }
        }
    }
}
