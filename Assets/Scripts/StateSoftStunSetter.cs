using UnityEngine;
//using UnityEditor;

public class StateSoftStunSetter : StateMachineBehaviour {
    public static string[] activeTags = { "Idle", "Move" };
    public static string[] inactiveTags = { "Attack", "Blocked" };

    public override void OnStateEnter (Animator animator, AnimatorStateInfo animatorStateInfo, int layerIndex) {
        var fighter = animator.gameObject.GetComponent<Fighter> ();
        foreach (var tag in activeTags) {
            if (animatorStateInfo.IsTag(tag)) {
                fighter.SoftStun = false;
                return;
            }
        }
        foreach (var tag in inactiveTags) {
            if (animatorStateInfo.IsTag (tag)) {
                fighter.SoftStun = true;
                return;
            }
        }
    }
}