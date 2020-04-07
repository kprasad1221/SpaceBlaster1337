using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [Tooltip("Explosion Prefab with ParticleSys and AudioSrc")] [SerializeField] GameObject explosionFX;
    [SerializeField] Transform parent;

    private void Start()
    {
        AddNonTriggerBoxCollider();
    }

    private void AddNonTriggerBoxCollider()
    {
        Collider boxCollider = gameObject.AddComponent<BoxCollider>();
        boxCollider.isTrigger = false;
    }

    private void OnParticleCollision(GameObject other)
    {
        print("particle collided w/Enemy " + gameObject.name);
        GameObject fx = Instantiate(explosionFX, transform.position, Quaternion.identity);
        fx.transform.parent = parent;
        fx.name = gameObject.name + "_Explosion";
        Destroy(gameObject);
    }
}
