using UnityEngine;
using System.Collections.Generic;

public interface IControlEngine2D {
    /// <summary>
    /// Set the engine's movement under whatever standard motion rules the engine defines.
    /// </summary>
    /// <param name="input">The Vector2 defining the motion of the engine.</param>
    void SetMovement (Vector2 input);
    /// <summary>
    /// Set the engine's velocity more directly than SetMovement will.
    /// </summary>
    /// <param name="velocity">The Vector2 defining the motion of the engine.</param>
    void SetVelocity (Vector2 velocity);
}
