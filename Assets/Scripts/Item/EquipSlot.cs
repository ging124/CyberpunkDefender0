using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EquipSlot : ItemSlot
{
    [SerializeField] private Image image;

    public void Equip(Item item)
    {
        if(this.item.itemType == item.itemType)
        {
            gameObject.SetActive(true);
            this.item = item;
            this.image.sprite = item.GetSprite();
            GetRarityColor(item);
        }
    }

    public void UnequipItem()
    {
        PlayerController.instance.playerGearEquipment.UnequipItem(item);
        PlayerController.instance.playerInventory.inventory.AddItem(item);
        OnCursorExit();
    }
}
