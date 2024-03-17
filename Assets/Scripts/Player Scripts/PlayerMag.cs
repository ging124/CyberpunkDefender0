using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMag : MonoBehaviour
{
    private int maxMags;
    private int maxBullets;

    private int currentMags;
    private int currentBullets;

    void Awake()
    {
        currentMags = maxMags;
        currentBullets = maxBullets;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
