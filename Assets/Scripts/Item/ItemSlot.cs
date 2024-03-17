using System;
using UnityEngine;
using UnityEngine.UI;

[Serializable]
public class ItemSlot : MonoBehaviour
{
    public Item item;
    public RawImage rarityImage;


    public void OnCursorEnter()
    {
        UI_Controller.instance.uiInventory.DisplayItemInfo(item, item.GetSprite(), transform.position);
    }

    public void OnCursorExit()
    {
        UI_Controller.instance.uiInventory.DestroyItemInfo();
    }

    public void EquipItem()
    {
        if (PlayerController.instance.playerLevel.playerLevel < item.reqLevel) return;

        if (PlayerController.instance.playerGearEquipment.maskItem.itemType == item.itemType && PlayerController.instance.playerGearEquipment.maskItem.itemName != "") return;
        if (PlayerController.instance.playerGearEquipment.clothItem.itemType == item.itemType && PlayerController.instance.playerGearEquipment.clothItem.itemName != "") return;
        if (PlayerController.instance.playerGearEquipment.gloveItem.itemType == item.itemType && PlayerController.instance.playerGearEquipment.gloveItem.itemName != "") return;
        if (PlayerController.instance.playerGearEquipment.bootsItem.itemType == item.itemType && PlayerController.instance.playerGearEquipment.bootsItem.itemName != "") return;

        PlayerController.instance.playerGearEquipment.EquipItem(item);
        PlayerController.instance.playerInventory.inventory.RemoveItem(item);
        Destroy(gameObject);
        OnCursorExit();
    }

    public void GetItem(Item item)
    {
        this.item = item;
    }

    public void GetRarityColor(Item item)
    {
        if (item.itemRarity == Item.Rarity.rare)
        {
            rarityImage.color = new Color32(125, 197, 253, 255);
        }
        else if (item.itemRarity == Item.Rarity.epic)
        {
            rarityImage.color = new Color32(179, 125, 253, 255);
        }
        else if (item.itemRarity == Item.Rarity.legendary)
        {
            rarityImage.color = new Color32(255, 230, 97, 255);
        }
    }

    public void DeleteItem()
    {
        PlayerController.instance.playerInventory.inventory.RemoveItem(item);
        Destroy(gameObject);
        OnCursorExit();
    }
}
