using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerEffect : MonoBehaviour
{
    public List<Transform> listEffect;

    void Start()
    {
        GetEffect();

        Deactive();
    }

    void Update()
    {
        if(PlayerController.instance.playerEquipment.isMeleAttack)
        {
            Deactive();
        }
        else if (PlayerController.instance.playerEquipment.isRifleShooting)
        {
            listEffect[1].gameObject.SetActive(false);
            if(PlayerController.instance.playerAttack.isRifleReloading || (PlayerController.instance.playerAttack.rifleCurrentMag <= 0 && PlayerController.instance.playerAttack.rifleCurrentAmmo <= 0))
            {
                listEffect[0].gameObject.SetActive(false);
            }
        }
        else
        {
            listEffect[0].gameObject.SetActive(false);
            if (PlayerController.instance.playerAttack.isPistolReloading || (PlayerController.instance.playerAttack.rifleCurrentMag <= 0 && PlayerController.instance.playerAttack.rifleCurrentAmmo <= 0))
            {
                listEffect[1].gameObject.SetActive(false);
            }
        }
    }


    public void GetEffect()
    {
        foreach (Transform child in transform)
        {
            if (child != null)
            {
                listEffect.Add(child);
            }
        }
    }

    public void Deactive()
    {
        foreach(Transform effect in listEffect)
        {
            if (effect != null)
            {
                effect.gameObject.SetActive(false);
            }
        }
    }
}
