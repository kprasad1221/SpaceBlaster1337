using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private void Start()
    {
        gameObject.AddComponent<BoxCollider>();
    }
    private void OnParticleCollision(GameObject other)
    {
        print("particle collided w/Enemy " + gameObject.name);
        Destroy(gameObject);
    }
}
