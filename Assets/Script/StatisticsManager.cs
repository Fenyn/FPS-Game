using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatisticsManager : MonoBehaviour {

    public float maxHealth;
    private float currentHealth;

    public float moveSpeed;

    public GameObject bulletGO;

    public float CurrentHealth {
        get {
            return currentHealth;
        }

        set {
            currentHealth = value;
        }
    }

    public float MaxHealth {
        get {
            return maxHealth;
        }

        set {
            maxHealth = value;
        }
    }

    // Use this for initialization
    void Start() {
        CurrentHealth = MaxHealth;
    }

    private void FixedUpdate() {
        if (currentHealth <= -maxHealth) {
            Debug.Log(currentHealth);
            Debug.Log(maxHealth);
            Debug.Log("Destroying object " + gameObject.name);
            Destroy(this.gameObject);
        }
    }

    private void OnCollisionEnter(Collision collision) {
        if (collision.gameObject.tag == "bullet") {
            Debug.Log("Reducing health by 10");
            currentHealth -= 10;
        }
    }

}
