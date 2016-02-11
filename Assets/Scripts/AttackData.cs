using UnityEngine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class AttackData : ScriptableObject {
    public int priority = 0;
    public float dmg = 0;
    public float chip = 0;
    public Vector2 launch = Vector2.zero;
    public bool launchState = false;
}
