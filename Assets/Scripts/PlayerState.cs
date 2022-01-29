using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class PlayerState {

    public static float speed = 0.0F;
    public static Vector2 velocity = new Vector2(0, 0);
    public static Vector2 localScale = new Vector2(0, 0);
    public static float percentage = 0.0F;

    public static void SetPlayerInit(PlatPlayer player, float pct) {
        speed = player.GetSpeed();
        velocity = player.GetVelocity();
        localScale = player.GetLocalScale();
        percentage = pct;
    }
}