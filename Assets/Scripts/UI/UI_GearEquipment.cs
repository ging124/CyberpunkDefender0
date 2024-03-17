using UnityEngine;

public class UI_GearEquipment : MonoBehaviour
{
    [SerializeField] private Transform maskSlotEquiment;
    [SerializeField] private Transform clothSlotEquiment;
    [SerializeField] private Transform gloveSlotEquiment;
    [SerializeField] private Transform bootsSlotEquiment;

    void Update()
    {
        if (PlayerController.instance.playerGearEquipment.maskItem.itemName != "")
        {
            maskSlotEquiment.GetComponent<EquipSlot>().Equip(PlayerController.instance.playerGearEquipment.maskItem);
            maskSlotEquiment.gameObject.SetActive(true);
        }
        else
        {
            maskSlotEquiment.gameObject.SetActive(false);
        }

        if (PlayerController.instance.playerGearEquipment.clothItem.itemName != "")
        {
            clothSlotEquiment.GetComponent<EquipSlot>().Equip(PlayerController.instance.playerGearEquipment.clothItem);
            clothSlotEquiment.gameObject.SetActive(true);
        }
        else
        {
            clothSlotEquiment.gameObject.SetActive(false);
        }

        if (PlayerController.instance.playerGearEquipment.gloveItem.itemName != "")
        {
            gloveSlotEquiment.GetComponent<EquipSlot>().Equip(PlayerController.instance.playerGearEquipment.gloveItem);
            gloveSlotEquiment.gameObject.SetActive(true);
        }
        else
        {
            gloveSlotEquiment.gameObject.SetActive(false);
        }

        if (PlayerController.instance.playerGearEquipment.bootsItem.itemName != "")
        {
            bootsSlotEquiment.GetComponent<EquipSlot>().Equip(PlayerController.instance.playerGearEquipment.bootsItem);
            bootsSlotEquiment.gameObject.SetActive(true);
        }
        else
        {
            bootsSlotEquiment.gameObject.SetActive(false);
        }
    }
}
