using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelfDestruct : MonoBehaviour
{
    [Tooltip("In Seconds")] [SerializeField] float selfDestructDelayTime;
    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, selfDestructDelayTime);
    }

}
