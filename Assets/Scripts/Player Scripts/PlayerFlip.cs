using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFlip : MonoBehaviour
{
    public void FlipObject()
    {
        if (PlayerController.instance.playerMovement.movement < 0)
        {
            PlayerController.instance.player.transform.rotation = Quaternion.Euler(0, -180, 0);
        }
        else if (PlayerController.instance.playerMovement.movement > 0)
        {
            PlayerController.instance.player.transform.rotation = Quaternion.Euler(0, 0, 0);
        }
    }
}
