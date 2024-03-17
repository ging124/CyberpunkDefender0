using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDead : MonoBehaviour
{
    public void Dead()
    {
        PlayerController.instance.animator.SetTrigger("isDead");
        PlayerController.instance.playerAttack.enabled = false;
        PlayerController.instance.playerHurt.enabled = false;
        PlayerController.instance.playerMovement.enabled = false;
        Invoke(nameof(PlayerDeactive), 0.5f);
    }

    void PlayerDeactive()
    {
        PlayerController.instance.player.SetActive(false);
    }
}
