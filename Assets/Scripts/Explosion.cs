using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion : MonoBehaviour
{
    public float damage = 6.9F;
    public Vector2 knockback = new Vector2(0, 0);
    public float duration = 1.0F;
    private List<Character> charactersHit = new List<Character>();
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(KillExplode());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator KillExplode() {
        WaitForSeconds wait = new WaitForSeconds(duration);

        yield return wait;
        Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        Character character = other.gameObject.GetComponent<Character>();
        if (character != null && !charactersHit.Contains(character)) { 
            character.TakeDamage(new ExplosionAttack(damage, knockback), false);
            charactersHit.Add(character);
        }
    }
}
