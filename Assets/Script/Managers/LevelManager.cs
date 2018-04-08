using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour {

    int currentLevel;
    int numOfActiveCollectables;
    LevelManager instance;

    private void Awake() {
        if(instance == null) {
            instance = this;
        } else if (instance != this) {
            Destroy(gameObject);
        }
    }

    public void CompleteLevel() {
        currentLevel++;
        LoadLevel(currentLevel);
    }

    public void LoadLevel(int sceneIndex) {
        SceneManager.LoadSceneAsync(sceneIndex);
    }
}
