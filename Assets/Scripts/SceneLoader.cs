using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    [Range(1.5f, 10f)] [SerializeField] float levelLoadDelay = 3f;
    // Start is called before the first frame update
    void Start()
    {
        Invoke("LoadLevel", levelLoadDelay);
    }

    private void LoadLevel()
    {
        SceneManager.LoadScene(1);
    }
}
