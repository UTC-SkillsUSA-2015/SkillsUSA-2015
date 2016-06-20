using UnityEngine;

public abstract class AbstractFighter : MonoBehaviour {
    // Update is called every frame, if the MonoBehaviour is enabled
    public void Update () {
        UpdateFacing ();
        UpdateAttacks ();
        UpdateMovement ();
        UpdateAnimator ();
        UpdateAudio ();
    }

    protected abstract void UpdateAudio ();
    protected abstract void UpdateAnimator ();
    protected abstract void UpdateAttacks ();
    protected abstract void UpdateFacing ();
    protected abstract void UpdateMovement ();
}