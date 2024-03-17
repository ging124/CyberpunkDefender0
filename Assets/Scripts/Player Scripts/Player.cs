using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collider)
     {
        ItemWorld itemWorld = collider.GetComponent<ItemWorld>();
        if (itemWorld != null)
        {
            PlayerController.instance.playerInventory.inventory.AddItem(itemWorld.GetItem());
            itemWorld.DestroySelf();
        }
    }
}
