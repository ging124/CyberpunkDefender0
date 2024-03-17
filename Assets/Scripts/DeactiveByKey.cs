using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeactiveByKey : MonoBehaviour
{

    void Update()
    {
        if (Input.GetKeyUp(KeyCode.J))
        {
            gameObject.SetActive(false);
        }
    }
}
