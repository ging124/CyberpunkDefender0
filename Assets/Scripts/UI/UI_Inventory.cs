using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UI_Inventory : MonoBehaviour
{
    [SerializeField]
    private Inventory inventory;
    [SerializeField]
    private Transform itemSlotContanier;
    [SerializeField]
    private Transform itemSlotTemplate;
    [SerializeField]
    private TMP_Text slotCount;

    [SerializeField]
     Transform canvas;
    [SerializeField]
    private GameObject currentItemInfo;
    [SerializeField]
    private GameObject itemInfoPrefab;

    [SerializeField]
    private float moveX = 0f;
    [SerializeField]
    private float moveY = 0f;

    private void Awake()
    {
        itemSlotContanier = transform.Find("itemSlotContanier");
        itemSlotTemplate = itemSlotContanier.Find("itemSlotTemplate");
    }

    public void SetInventory(Inventory inventory)
    {
        this.inventory = inventory;

        inventory.OnItemListChanged += Inventory_OnItemListChanged;
        RefreshInventoryItems();
    }

    private void Inventory_OnItemListChanged(object sender, System.EventArgs args)
    {
        RefreshInventoryItems();
    }

    private void RefreshInventoryItems()
    {
        foreach (Transform child in itemSlotContanier)
        {
            if (child == itemSlotTemplate) continue;
            Destroy(child.gameObject);
        }
        int x = 0;
        int y = 0;
        float itemSlotCellSize = 30f;
        foreach (Item item in inventory.GetItemList())
        {
            RectTransform itemSlotRectTransform = Instantiate(itemSlotTemplate, itemSlotContanier).GetComponent<RectTransform>();
            itemSlotRectTransform.gameObject.SetActive(true);
            itemSlotRectTransform.gameObject.GetComponent<ItemSlot>().GetItem(item);
            itemSlotRectTransform.gameObject.GetComponent<ItemSlot>().GetRarityColor(item);


            itemSlotRectTransform.anchoredPosition = new Vector2(x * itemSlotCellSize, y * itemSlotCellSize);
            Image image = itemSlotRectTransform.Find("image").GetComponent<Image>();
            image.sprite = item.GetSprite();

            x++;
            if (x > 4)
            {
                x = 0;
                y++;
            }
        }
        SetInventoryCountSlot();
    }

    public void DisplayItemInfo(Item item, Sprite imageItem, Vector2 buttonPos)
    {
        if (currentItemInfo != null)
        {
            Destroy(currentItemInfo.gameObject);
        }

        if(buttonPos.x >= 1000)
        {
            buttonPos.x += moveX;
            buttonPos.y += moveY;
        }
        else
        {
            buttonPos.x -= moveX;
            buttonPos.y += moveY;
        }

        currentItemInfo = Instantiate(itemInfoPrefab, buttonPos, Quaternion.identity, canvas);
        currentItemInfo.GetComponent<UI_DetailsItem>().SetUp(item, imageItem);
    }

    public void DestroyItemInfo()
    {
        if (currentItemInfo != null)
        {
            Destroy(currentItemInfo.gameObject);
        }
    }

    public void SetInventoryCountSlot()
    {
        if(inventory.itemList.Count < 48)
        {
            slotCount.color = Color.white;
            slotCount.text =  $"SLOT: {inventory.itemList.Count}/48" ;
        }
        else
        {
            slotCount.color = Color.red;
            slotCount.text = $"SLOT: 48/48";
            PlayerController.instance.playerInventory.canGetItem = false;

        }
    }
}
