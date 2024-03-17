using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightningChain : MonoBehaviour
{
    void Start()
    {
        if(gameObject.transform.eulerAngles.y == 180) 
        {
            Debug.Log("true");
        }
    }
}
