using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameLauncher : MonoBehaviour
{

    [Range(1.5f, 10f)] [SerializeField] float levelLoadDelay = 3f;

    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }
    void Start()
    {
        Invoke("LoadLevel", levelLoadDelay);
    }

    private void LoadLevel()
    {
        SceneManager.LoadScene(1);  
    }
}
