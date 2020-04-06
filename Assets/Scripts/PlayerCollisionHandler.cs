using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerCollisionHandler : MonoBehaviour
{

    [Tooltip("In Seconds")][SerializeField] float levelLoadDelay = 1.5f;
    [Tooltip("Particle Effects Prefab")][SerializeField] GameObject deathFX;

    private void OnTriggerEnter(Collider other)
    {
        StartDeathSequence();

    }

    private void StartDeathSequence()
    {
        print("player hit, stopMovement");
        SendMessage("OnPlayerDeath");
        deathFX.SetActive(true);
        Invoke("ReloadCurrentLevel", levelLoadDelay);
    }

    private void ReloadCurrentLevel() //string referenced in StartDeathSequence Method
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex);
    }
}
