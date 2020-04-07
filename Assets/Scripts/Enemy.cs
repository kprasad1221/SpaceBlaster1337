using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [Tooltip("Explosion Prefab with ParticleSys and AudioSrc")] [SerializeField] GameObject explosionFX;
    [SerializeField] Transform parent;
    [SerializeField] int scorePerHit = 12;
    [SerializeField] int maxHits = 10;
    ScoreBoard scoreBoard;

    private void Start()
    {
        AddNonTriggerBoxCollider();
        scoreBoard = FindObjectOfType<ScoreBoard>();
    }

    private void AddNonTriggerBoxCollider()
    {
        Collider boxCollider = gameObject.AddComponent<BoxCollider>();
        boxCollider.isTrigger = false;
    }

    private void OnParticleCollision(GameObject other)
    {
        print("particle collided w/Enemy " + gameObject.name);
        maxHits = maxHits - 1;
        if(maxHits <= 1)
        {
            DestroyEnemy();
        }
    }

    private void DestroyEnemy()
    {
        scoreBoard.ScoreHit(scorePerHit);
        GameObject fx = Instantiate(explosionFX, transform.position, Quaternion.identity);
        fx.transform.parent = parent;
        fx.name = gameObject.name + "_Explosion";
        Destroy(gameObject);
    }
}
