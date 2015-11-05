using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

public interface IControlEngine2D {
    void SetMovement (Vector2 input);
    void SetVelocity (Vector2 velocity);
}
