using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBullet : MonoBehaviour
{
    public List<Transform> listBullet;

    void Start()
    {
        GetBullet();

        Deactive();
    }

    void GetBullet()
    {
        foreach (Transform child in transform)
        {
            if (child != null)
            {
                listBullet.Add(child);
            }
        }
    }

    void Deactive()
    {
        foreach (Transform bullet in listBullet)
        {
            if (bullet != null)
            {
                bullet.gameObject.SetActive(false);
            }
        }
    }
}
