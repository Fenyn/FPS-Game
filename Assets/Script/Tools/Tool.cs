using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Tool : ScriptableObject {
    float toolDistance;

    public virtual float ToolDistance {
        get {
            return toolDistance;
        }

        set {
            toolDistance = value;
        }
    }

    public abstract RaycastHit ActivatePrimary();
    public abstract void ActivateSecondary();
}
