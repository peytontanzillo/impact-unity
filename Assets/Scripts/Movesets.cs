using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum AttackDirection { FRONT, BACK, UP, DOWN, NEUTRAL };

public enum MovesetType { SWORD, MAGE, BOMBER };

public class Moveset
{
    Dictionary<AttackDirection, Attack> attacks = new Dictionary<AttackDirection, Attack>();
    public void AddAttack(AttackDirection direction, Attack attack) {
        attacks.Add(direction, attack);
    }
    public Attack GetAttack(AttackDirection direction) {
        return attacks[direction];
    }
}

public static class Movesets {
    static Dictionary<MovesetType, Moveset> movesets = new Dictionary<MovesetType, Moveset>();

    public static Moveset GetMoveset(MovesetType type) {
        if (movesets.Keys.Count == 0) {
            PopulateMovesets();
        }
        return movesets[type];
    }
    public static void PopulateMovesets() {
        Moveset swordMoveset = new Moveset();
        swordMoveset.AddAttack(AttackDirection.FRONT, new MeleeAttack("Attack_Front", 2.0F, new Vector2(10.0F, 10.0F)));
        swordMoveset.AddAttack(AttackDirection.BACK, new MeleeAttack("Attack_Back", 1.2F, new Vector2(8.0F, 0.0F)));
        swordMoveset.AddAttack(AttackDirection.UP, new MeleeAttack("Attack_Up", 3.1F, new Vector2(0.0F, 15.0F)));
        swordMoveset.AddAttack(AttackDirection.DOWN, new MeleeAttack("Attack_Down", .5F, new Vector2(7.0F, 3.0F)));
        swordMoveset.AddAttack(AttackDirection.NEUTRAL, new MeleeAttack("Attack_Neutral", 1.3F, new Vector2(7.0F, 7.0F)));
        movesets.Add(MovesetType.SWORD, swordMoveset);

        Moveset mageMoveset = new Moveset();
        mageMoveset.AddAttack(AttackDirection.FRONT, new MeleeAttack("Attack_Front", 2.0F, new Vector2(10.0F, 10.0F)));
        mageMoveset.AddAttack(AttackDirection.BACK, new MeleeAttack("Attack_Back", 1.2F, new Vector2(8.0F, 0.0F)));
        mageMoveset.AddAttack(AttackDirection.UP, new MeleeAttack("Attack_Up", 3.1F, new Vector2(0.0F, 15.0F)));
        mageMoveset.AddAttack(AttackDirection.DOWN, new MeleeAttack("Attack_Down", .5F, new Vector2(7.0F, 3.0F)));
        mageMoveset.AddAttack(AttackDirection.NEUTRAL, new ProjectileAttack(null, 3F, new Vector2(7.0F, 7.0F), "Projectile"));
        movesets.Add(MovesetType.MAGE, mageMoveset);

        Moveset bomberMoveset = new Moveset();
        bomberMoveset.AddAttack(AttackDirection.FRONT, new MeleeAttack("Attack_Front", 2.0F, new Vector2(10.0F, 10.0F)));
        bomberMoveset.AddAttack(AttackDirection.BACK, new MeleeAttack("Attack_Back", 1.2F, new Vector2(8.0F, 0.0F)));
        bomberMoveset.AddAttack(AttackDirection.UP, new MeleeAttack("Attack_Up", 3.1F, new Vector2(0.0F, 15.0F)));
        bomberMoveset.AddAttack(AttackDirection.DOWN, new MeleeAttack("Attack_Down", .5F, new Vector2(7.0F, 3.0F)));
        bomberMoveset.AddAttack(AttackDirection.NEUTRAL, new ProjectileAttack(null, 3F, new Vector2(7.0F, 7.0F), "Bomb", "Explosion"));
        movesets.Add(MovesetType.BOMBER, bomberMoveset);
    }

}


