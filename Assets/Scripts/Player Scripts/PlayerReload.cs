using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerReload : MonoBehaviour
{
    void Update()
    {
        if (PlayerController.instance.playerEquipment.isRifleShooting)
        {
            InputRifleReload();
        }
        else
        {
            InputPistolReload();
        }

    }

    void InputRifleReload()
    {
        if(PlayerController.instance.playerAttack.rifleCurrentMag <= 0)
        {
            return;
        }

        if (PlayerController.instance.playerAttack.rifleCurrentAmmo < PlayerController.instance.playerAttack.rifleMaxAmmo && Input.GetKeyDown(KeyCode.R))
        {
            StartCoroutine(PlayerController.instance.playerAttack.RifleReload());
        }
    }

    void InputPistolReload()
    {
        if (PlayerController.instance.playerAttack.pistolCurrentMag <= 0)
        {
            return;
        }

        if (PlayerController.instance.playerAttack.pistolCurrentAmmo < PlayerController.instance.playerAttack.pistolMaxAmmo && Input.GetKeyDown(KeyCode.R))
        {
            StartCoroutine(PlayerController.instance.playerAttack.PistolReload());
        }
    }
}
