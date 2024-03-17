using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UI_DetailsItem : MonoBehaviour
{
    private TMP_Text nameItem;
    private Image imageItem;
    private TMP_Text reqLevel;
    private TMP_Text textATK;
    private TMP_Text textHP;
    private TMP_Text textSPD;
    private Image imageATK;
    private Image imageHP;
    private Image imageSPD;

    void Awake()
    {
        nameItem = transform.Find("ItemName").GetComponent<TMP_Text>();
        imageItem = transform.Find("ItemImage").GetComponent<Image>();
        reqLevel = transform.Find("RequireLevel").GetComponent<TMP_Text>();
        textATK = transform.Find("ATKPoint").GetComponent<TMP_Text>();
        textHP = transform.Find("HPPoint").GetComponent<TMP_Text>();
        textSPD = transform.Find("SPDPoint").GetComponent<TMP_Text>();
        imageATK = transform.Find("ATKImage").GetComponent<Image>();
        imageHP = transform.Find("HPImage").GetComponent<Image>();
        imageSPD = transform.Find("SPDImage").GetComponent<Image>();
    }

    void Update()
    {
        if(UI_Controller.instance.isInventoryMenuOpen == false)
        {
            gameObject.SetActive(false);
        }
    }

    public void SetUp(Item item, Sprite imageItem)
    {
        CleanDetailItem(item);
        this.nameItem.text = item.itemName;
        this.imageItem.sprite = imageItem;
        this.reqLevel.text = $"REQ LV : {item.reqLevel}";
        this.textATK.text = $"+ {item.atkPoint} ATK";
        this.textHP.text = $"+ {item.hpPoint} HP";
        this.textSPD.text = $"+ {item.spdPoint} SPD";
    }

    public void CleanDetailItem(Item item)
    {
        if (PlayerController.instance.playerLevel.playerLevel < item.reqLevel)
        {
            this.reqLevel.color = Color.red;
        }

        if(item.atkPoint == 0)
        {
            this.textATK.gameObject.SetActive(false);
            this.imageATK.gameObject.SetActive(false);
        }
        if (item.hpPoint == 0)
        {
            this.textHP.gameObject.SetActive(false);
            this.imageHP.gameObject.SetActive(false);
        }
        if (item.spdPoint == 0)
        {
            this.textSPD.gameObject.SetActive(false);
            this.imageSPD.gameObject.SetActive(false);
        }
    }
}
