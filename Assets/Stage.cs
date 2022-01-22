using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stage : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        other.gameObject.transform.position = new Vector2(0, 0);
        other.gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);
        if (other.gameObject.tag == "Enemy")
        {
            other.gameObject.GetComponent<Enemy>().SetPercentage(0.0F);
        }
    }
}
