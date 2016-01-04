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
    /// Speed and direction the engine should move the object in.
    /// </summary>
    float WalkMotion { set; }
}
