using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum AttackDirection { FRONT, BACK, UP, DOWN, NEUTRAL };

public enum MovesetType { SWORD };

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
        return movesets[type];
    }
    public static void PopulateMovesets() {
        Moveset swordMoveset = new Moveset();
        swordMoveset.AddAttack(AttackDirection.FRONT, new Attack("Attack_Front", 2.0F, new Vector2(10.0F, 10.0F)));
        swordMoveset.AddAttack(AttackDirection.BACK, new Attack("Attack_Back", 1.2F, new Vector2(8.0F, 0.0F)));
        swordMoveset.AddAttack(AttackDirection.UP, new Attack("Attack_Up", 3.1F, new Vector2(0.0F, 15.0F)));
        swordMoveset.AddAttack(AttackDirection.DOWN, new Attack("Attack_Down", .5F, new Vector2(7.0F, 3.0F)));
        swordMoveset.AddAttack(AttackDirection.NEUTRAL, new Attack("Attack_Neutral", 1.3F, new Vector2(7.0F, 7.0F)));
        movesets.Add(MovesetType.SWORD, swordMoveset);
    }

}


