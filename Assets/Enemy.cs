using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Enemy : MonoBehaviour
{
    public float weight = 50.0f;
    public float verticalForce = 10.0f;
    public float horizontalForce = 10.0f;


    float _percentage = 0.0F;
    Text textObject;
    private Rigidbody2D _body;
    // Start is called before the first frame update
    void Start()
    {
        _body = GetComponent<Rigidbody2D>();  
        textObject = GameObject.Find("Enemy Health").GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void TakeDamage(string attackState) {
        SetPercentage(_percentage + 5.0F);
        float xForce = horizontalForce * (1 / weight) * _percentage;
        float yForce = verticalForce * (1 / weight) * _percentage;

        switch (attackState) {
            case "Attack_Right":
                _body.velocity = new Vector2(xForce, yForce);
                break;
            case "Attack_Left":
                _body.velocity = new Vector2(-1 * xForce, yForce);
                break;
        }

    }

    public void SetPercentage(float percentage) {
        _percentage = percentage;
        textObject.text = _percentage + "%";
    }
}
