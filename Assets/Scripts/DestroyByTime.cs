using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyByTime : MonoBehaviour
{
    [SerializeField]
    private float timeToDestroy = 0.5f;

    void Update()
    {
        Destroy(gameObject, timeToDestroy);
    }
}
