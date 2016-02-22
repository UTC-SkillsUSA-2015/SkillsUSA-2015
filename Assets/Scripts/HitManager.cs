using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class HitManager : MonoBehaviour {
    HashSet<Attack> m_previousAttacks = new HashSet<Attack> ();
    HashSet<Attack> m_currentAttacks = new HashSet<Attack> ();

    public int DamageDealt {
        get {
            if (m_currentAttacks.Count == 0) {
                return 0;
            }
            else {
                var sum = 0;
                foreach (var atk in m_currentAttacks) {
                    sum += atk.TotalDamage;
                }
                m_currentAttacks.Clear ();
                return sum;
            }
        }
    }

    // Use this for initialization
    void Start () {

    }

    // Update is called once per frame
    void Update () {

    }

    public void AddAttack (Attack atk) {
        if (!m_previousAttacks.Contains (atk)) {
            m_previousAttacks.Add (atk);
            m_currentAttacks.Add (atk);
        }
    }
}
