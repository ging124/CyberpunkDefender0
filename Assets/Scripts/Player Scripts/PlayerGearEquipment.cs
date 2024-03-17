using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Item;

public class PlayerGearEquipment : MonoBehaviour
{
    [field: SerializeField] public Item maskItem { get; private set; }
    [field: SerializeField] public Item clothItem { get; private set; }
    [field: SerializeField] public Item gloveItem { get; private set; }
    [field: SerializeField] public Item bootsItem { get; private set; }

    [SerializeField] private Item maskItemDefault;
    [SerializeField] private Item clothItemDefault;
    [SerializeField] private Item gloveItemDefault;
    [SerializeField] private Item bootsItemDefault;


    void Awake()
    {
        maskItem.itemType = ItemType.Mask;
        clothItem.itemType = ItemType.Cloth;
        gloveItem.itemType = ItemType.Glove;
        bootsItem.itemType = ItemType.Boots;

        maskItemDefault = maskItem;
        clothItemDefault = clothItem;
        gloveItemDefault = gloveItem;
        bootsItemDefault = bootsItem;
    }

    public void EquipItem(Item item)
    {

        if (maskItem.itemType == item.itemType)
        {
            maskItem = item;
        }
        else if(clothItem.itemType == item.itemType)
        {
            clothItem = item;
        }
        else if(gloveItem.itemType == item.itemType)
        {
            gloveItem = item;
        }
        else
        {
            bootsItem = item;
        }

        EquipUpdateStart(item);
    }

    public void UnequipItem(Item item)
    {
        if (maskItem.itemType == item.itemType)
        {
            maskItem = maskItemDefault;
        }
        else if (clothItem.itemType == item.itemType)
        {
            clothItem = clothItemDefault;
        }
        else if (gloveItem.itemType == item.itemType)
        {
            gloveItem = gloveItemDefault;
        }
        else
        {
            bootsItem = bootsItemDefault;
        }

        UnequipUpdateStart(item);
    }

    public void EquipUpdateStart(Item item)
    {
        PlayerController.instance.playerAttack.attackDamage += item.atkPoint;
        PlayerController.instance.playerAttack.rifleAttackDamage += item.atkPoint;
        PlayerController.instance.playerAttack.pistolAttackDamage += item.atkPoint;

        PlayerController.instance.playerHurt.maxHp += item.hpPoint;
        PlayerController.instance.playerHurt.currentHp += item.hpPoint;

        PlayerController.instance.playerMovement.moveSpeed += item.spdPoint;
    }

    public void UnequipUpdateStart(Item item)
    {
        PlayerController.instance.playerAttack.attackDamage -= item.atkPoint;
        PlayerController.instance.playerAttack.rifleAttackDamage -= item.atkPoint;
        PlayerController.instance.playerAttack.pistolAttackDamage -= item.atkPoint;

        PlayerController.instance.playerHurt.maxHp -= item.hpPoint;
        PlayerController.instance.playerHurt.currentHp -= item.hpPoint;

        PlayerController.instance.playerMovement.moveSpeed -= item.spdPoint;
    }
}
