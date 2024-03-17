using UnityEngine;

public class PlayerInventory : MonoBehaviour
{
    public Inventory inventory;
    public bool canGetItem = true;
    public float money;

    private void Awake()
    {
        money = 0;
        inventory = new Inventory();
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (canGetItem)
        {
            ItemWorld itemWorld = collider.GetComponent<ItemWorld>();
            if (itemWorld != null)
            {
                inventory.AddItem(itemWorld.GetItem());
                itemWorld.DestroySelf();
            }
        }
    }

    public void GetMoney(float money)
    {
        this.money += money;
    }
}
