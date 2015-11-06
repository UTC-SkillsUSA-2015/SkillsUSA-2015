using System;
using UnityEngine.Events;

public interface ISimplePlatformEngine2D : IControlEngine2D {
    /// <summary>
    /// Make the engine jump.
    /// </summary>
    void Jump ();
    /// <summary>
    /// Details whether the engine's GameObject is currently on the ground.
    /// </summary>
    bool Grounded { get; }
    /// <summary>
    /// UnityEvent that is called when the engine moves from being
    /// grounded to not, or vice versa.
    /// </summary>
    // Note: This will need to be replaced by a class overriding
    // UnityEvent<bool>, so it will be serialized properly
    UnityEvent<bool> GroundStateChanged { get; }
}
