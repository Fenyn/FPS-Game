using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatisticsManager : MonoBehaviour {

    public int maxHealth;
    public int currentHealth;

    public float moveSpeed = 10f;

    public GameObject bulletGO;

    public int CurrentHealth {
        get {
            return currentHealth;
        }

        set {
            currentHealth = value;
        }
    }

    public int MaxHealth {
        get {
            return maxHealth;
        }

        set {
            maxHealth = value;
        }
    }

    public float MoveSpeed {
        get {
            return moveSpeed;
        }

        set {
            moveSpeed = value;
        }
    }

    // Use this for initialization
    void Start() {
        CurrentHealth = MaxHealth;
    }

    private void FixedUpdate() {
        if (currentHealth <= 0) {
            Debug.Log("Destroying object " + gameObject.name);
            Destroy(this.gameObject);
        }
    }

    //Call this to deal damage to the object this is attached to.
    public void DealDamageToObject(int damage) {
        Debug.Log("Dealing " + damage.ToString() + " to HP pool: " + currentHealth);
        this.currentHealth -= damage;
        Debug.Log("Health is now" + currentHealth);
    }

}
