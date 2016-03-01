using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class HitManager : MonoBehaviour {
    Queue<Attack> m_currentAttacks = new Queue<Attack> ();
    Queue<Attack> m_attackHistory = new Queue<Attack> ();

    public Attack CurrentAttack {
        get {
            return m_currentAttacks.Peek ();
        }
    }
    public Attack PullAttack {
        get {
            return m_currentAttacks.Dequeue ();
        }
    }
    public bool HasAttack {
        get {
            return m_currentAttacks.Count != 0;
        }
    }

    [SerializeField]
    uint AttackRecordSize = 20;

    public void AddAttack (Attack atk) {
        if (!m_attackHistory.Contains (atk)) {
            m_attackHistory.Enqueue (atk);
            m_currentAttacks.Enqueue (atk);
            if (m_attackHistory.Count > AttackRecordSize)
                m_currentAttacks.Dequeue ();
        }
    }
}
