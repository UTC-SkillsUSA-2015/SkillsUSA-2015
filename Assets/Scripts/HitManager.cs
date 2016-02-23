using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class HitManager : MonoBehaviour {
    Queue<Attack> m_currentAttacks = new Queue<Attack> ();
    Queue<Attack> m_attackHistory = new Queue<Attack> ();
    
    public Attack CurrentAttack {
        get {
            return m_currentAttacks.Dequeue ();
        }
    }

    [SerializeField]
    uint AttackRecordSize;

    public void AddAttack (Attack atk) {
        if (!m_attackHistory.Contains (atk)) {
            m_attackHistory.Enqueue (atk);
            m_currentAttacks.Enqueue (atk);
            if (m_attackHistory.Count > AttackRecordSize) m_currentAttacks.Dequeue ();
        }
    }
}
