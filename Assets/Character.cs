using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public abstract class Character : MonoBehaviour
{
    public Text textObject;
    //public DefaultMoveset moveset;
    public float weight = 50.0f;
    public float verticalForce = 10.0f;
    public float horizontalForce = 10.0f;
    float percentage = 0.0F;
    public GameObject myPrefab;
    private Weapon weapon;



    // Start is called before the first frame update
    public void Start()
    {
        weapon = this.transform.GetComponentInChildren<Weapon>();
        weapon.SetBelongsTo(this);
    }

    public void TakeDamage(string attackState, GameObject gameObject)
    {
        SetPercentage(percentage + 5.0F);
        float xForce = horizontalForce * (1 / weight) * percentage;
        float yForce = verticalForce * (1 / weight) * percentage;

        switch (attackState) {
            case "Attack_Right":
                break;
            case "Attack_Left":
                xForce = -xForce;
                break;
        }

        Vector2 damageVector = new Vector2(xForce, yForce);
        this.AddDamageKnockback(damageVector);
    }

    public abstract void AddDamageKnockback(Vector2 vector);

    public void SetPercentage(float pct) {
        percentage = pct;
        textObject.text = percentage + "%";
    }

    public Weapon GetWeapon() {
        return weapon;
    }
}
