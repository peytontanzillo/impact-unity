using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class GlobalState {
    public static List<CharacterTemplate> party = new List<CharacterTemplate>();
    public static Dictionary<string, string> conversations = new Dictionary<string, string>();
    public static Dictionary<Vector3, bool> enemyDestroyed = new Dictionary<Vector3, bool>();
}