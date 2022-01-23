using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stage : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Movesets.PopulateMovesets();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        Character character = other.gameObject.GetComponent<Character>();
        if (character != null)
        {
            character.SetPercentage(0.0F);
            other.gameObject.transform.position = new Vector2(0, 0);
            other.gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);
        }
    }
}
