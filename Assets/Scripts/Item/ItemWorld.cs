using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemWorld : MonoBehaviour
{
    public static ItemWorld SpawnItemWorld(Vector3 position, Item item)
    {
        Transform transform = Instantiate(ItemAssets.Instance.pfItemWorld, position, Quaternion.identity);

        ItemWorld itemWorld = transform.GetComponent<ItemWorld>();
        itemWorld.SetItem(item);

        return itemWorld;
    }

    [SerializeField]
    private Item item;
    [SerializeField]
    private Color rareItemColor;
    [SerializeField]
    private Color epicItemColor;
    [SerializeField]
    private Color legendaryItemColor;
    private SpriteRenderer rarityImage;
    private SpriteRenderer spriteRenderer;

    void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        rarityImage = transform.Find("RarityImage").GetComponent<SpriteRenderer>();
    }

    public void SetItem(Item item)
    {
        this.item = item;
        spriteRenderer.sprite = item.GetSprite();
        GetRarityColor(item);
    }

    public Item GetItem()
    {
        return item;
    }

    public void GetRarityColor(Item item)
    {
        if(item.itemRarity == Item.Rarity.rare)
        {
            rarityImage.color = rareItemColor;
        }
        else if(item.itemRarity == Item.Rarity.epic)
        {
            rarityImage.color = epicItemColor;
        }
        else
        {
            rarityImage.color = legendaryItemColor;
        }
    }

    public void DestroySelf()
    {
        Destroy(gameObject);
    }
}
