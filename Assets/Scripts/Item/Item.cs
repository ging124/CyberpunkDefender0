using System;
using UnityEngine;

[Serializable]
public class Item
{
    public enum ItemType
    {
        Mask,
        Cloth,
        Glove,
        Boots,
    }

    public enum Rarity
    {
        rare,
        epic,
        legendary
    }

    public string itemName;
    public ItemType itemType;
    public Rarity itemRarity;
    public int reqLevel;
    public int atkPoint;
    public int hpPoint;
    public int spdPoint;

    public Sprite GetSprite()
    {
        if(reqLevel == 1)
        {
            switch (itemType)
            {
                default:
                case ItemType.Mask: return ItemAssets.Instance.maskSprite10;
                case ItemType.Cloth: return ItemAssets.Instance.clothSprite10;
                case ItemType.Glove: return ItemAssets.Instance.gloveSprite10;
                case ItemType.Boots: return ItemAssets.Instance.bootsSprite10;
            }
        }
        else if (reqLevel == 5)
        {
            switch (itemType)
            {
                default:
                case ItemType.Mask: return ItemAssets.Instance.maskSprite20;
                case ItemType.Cloth: return ItemAssets.Instance.clothSprite20;
                case ItemType.Glove: return ItemAssets.Instance.gloveSprite20;
                case ItemType.Boots: return ItemAssets.Instance.bootsSprite20;
            }
        }
        else if(reqLevel == 10)
        {
            switch (itemType)
            {
                default:
                case ItemType.Mask: return ItemAssets.Instance.maskSprite30;
                case ItemType.Cloth: return ItemAssets.Instance.clothSprite30;
                case ItemType.Glove: return ItemAssets.Instance.gloveSprite30;
                case ItemType.Boots: return ItemAssets.Instance.bootsSprite30;
            }
        }
        else
        {
            return null;
        }
    }

}
