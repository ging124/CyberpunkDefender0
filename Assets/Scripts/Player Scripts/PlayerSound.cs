using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSound : MonoBehaviour
{
    public AudioSource footstepsSound;
    public AudioSource lazerSound;
    public AudioSource slashSound;

    void Update()
    {
        if (Time.timeScale == 1)
        {
            FootstepsSound();

            if (Input.GetKey(KeyCode.J) && PlayerController.instance.playerAttack.isRifleReloading == false &&
                PlayerController.instance.playerEquipment.isLazerShooting == true &&
                PlayerController.instance.playerEquipment.isMeleAttack == false)
            {
                lazerSound.enabled = true;
            }
            else
            {
                lazerSound.enabled = false;
            }

            if (Input.GetKey(KeyCode.J) && PlayerController.instance.playerEquipment.isMeleAttack == true)
            {
                slashSound.enabled = true;
            }
            else
            {
                slashSound.enabled = false;
            }
        }
        else
        {
            footstepsSound.enabled = false;
            lazerSound.enabled = false;
            slashSound.enabled = false;
        }
    }

    void FootstepsSound()
    {
        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D))
        {
            footstepsSound.enabled = true;
        }
        else
        {
            footstepsSound.enabled = false;
        }
    }
}
