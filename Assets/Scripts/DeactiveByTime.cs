using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeactiveByTime : MonoBehaviour
{
    [SerializeField]
    private float timeToDeactive = 0.2f;

    void Update()
    {
        Invoke(nameof(Deactive), timeToDeactive);
    }

    void Deactive()
    {
        gameObject.SetActive(false);
    }
}
