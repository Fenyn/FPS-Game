using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhysicsGun : Tool {

    float toolDistance = 80f;
    float itemMoveSpeed;
    bool isActivated;

    float timeSinceLastMovement = 0f;

    public Transform itemToCarry;
    Rigidbody itemToCarryRigidbody;
    public Transform spotToCarry;

    public override float ToolDistance {
        get {
            return toolDistance;
        }

        set {
            toolDistance = value;
        }
    }

    public override RaycastHit ActivatePrimary() {
        Ray ray = Camera.main.ViewportPointToRay(new Vector3(.5f, .5f, 0));
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit, ToolDistance) && hit.transform.tag.Equals("item")) {
            return hit;
        }
        else {
            return hit;
        }
    }

    public override void ActivateSecondary() {
        Debug.Log("Activate Secondary on Phys Gun");
        isActivated = false;
    }

    private void MoveItem() {
        while (isActivated) {
            Debug.Log("Moving");
            float step = itemMoveSpeed * Time.deltaTime;
            itemToCarry.position = Vector3.MoveTowards(itemToCarry.position, spotToCarry.position, step);
        }
    }
}
