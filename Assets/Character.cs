using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public abstract class Character : MonoBehaviour
{
    public Text textObject;
    //public DefaultMoveset moveset;
    public float weight = 50.0f;
    public float percentage = 0.0F;
    protected Weapon weapon;
    public MovesetType movesetType;
    protected Moveset moveset;



    // Start is called before the first frame update
    public void Start()
    {
        weapon = this.transform.GetComponentInChildren<Weapon>();
        weapon.SetBelongsTo(this);
        moveset = Movesets.GetMoveset(movesetType);
    }

    public void TakeDamage(Attack attack, GameObject gameObject, bool isAttackerBackwards)
    {
        SetPercentage(percentage + attack.damage);
        float xForce = attack.knockback.x * (1 / weight) * percentage * (isAttackerBackwards ? -1 : 1);
        float yForce = attack.knockback.y * (1 / weight) * percentage;

        Vector2 damageVector = new Vector2(xForce, yForce);
        this.AddDamageKnockback(damageVector);
    }

    public abstract void AddDamageKnockback(Vector2 vector);

    public void SetPercentage(float pct) {
        percentage = pct;
        textObject.text = System.Math.Round(percentage, 1) + "%";
    }

    public Weapon GetWeapon() {
        return weapon;
    }
}
