using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Enemy : MonoBehaviour
{
    float _percentage = 0.0F;
    Text textObject;
    // Start is called before the first frame update
    void Start()
    {
        print(GameObject.Find("Enemy Health"));
        textObject = GameObject.Find("Enemy Health").GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void TakeDamage() {
        _percentage += 5.0F;
        textObject.text = _percentage + "%";
    }
}
