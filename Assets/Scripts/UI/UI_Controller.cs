using TMPro;
using Unity.VisualScripting.Antlr3.Runtime;
using UnityEngine;

public class UI_Controller : MonoBehaviour
{
    static public UI_Controller instance;

    public UI_Equipment uiEquipment;
    public UI_Esc uiEsc;
    public UI_Inventory uiInventory;
    public GameObject uiPlayerDead;
    public GameObject uiGameOver;
    public GameObject uiEquipmentWeapon;

    private TMP_Text timeSurvivalText;
    private float minute;
    private float second;

    private GameObject player;
    private PlayerSpawner playerSpawner;
    private GameObject fountain;

    public bool isEscMenuOpen { get; private set; } = false;
    public bool isInventoryMenuOpen { get; private set; } = false;
    public bool isEquipmentMenuOpen { get; private set; } = false;

    void Awake()
    {
        UI_Controller.instance = this;

        uiEquipment = transform.GetComponentInChildren<UI_Equipment>();
        uiEsc = transform.GetComponentInChildren<UI_Esc>();
        uiPlayerDead = GameObject.Find("UI_PlayerDead");
        uiGameOver = GameObject.Find("UI_GameOver");
        uiEquipmentWeapon = GameObject.Find("UI_EquipmentWeapon");

        timeSurvivalText = uiGameOver.transform.Find("TimeSurvivalText").GetComponent<TMP_Text>();
        uiInventory = GameObject.Find("UI_Inventory").GetComponent<UI_Inventory>();

        player = GameObject.Find("Character");
        playerSpawner = GameObject.Find("PlayerSpawner").GetComponent<PlayerSpawner>();
        fountain = GameObject.Find("Fountain");
    }

    void Start()
    {
        uiEsc.gameObject.SetActive(false);
        uiInventory.gameObject.SetActive(false);
        uiEquipmentWeapon.gameObject.SetActive(false);
        uiGameOver.gameObject.SetActive(false);
        uiPlayerDead.gameObject.SetActive(false);

        uiInventory.GetComponent<UI_Inventory>().SetInventory(PlayerController.instance.playerInventory.inventory);
    }

    void Update()
    {
        CheckPlayerDead();
        CheckFountanBroken();

        ActiveEscMenuByKey();

        ActiveInventoryByKey();
        CloseInventoryByKeyEsc();

        ActiveEquipmentByKey();
        CloseEquipmentByKeyEsc();
    }

    void CheckPlayerDead()
    {
        if (player.activeInHierarchy == true)
        {
            uiPlayerDead.gameObject.SetActive(false);
            return;
        }

        uiPlayerDead.gameObject.SetActive(true);
        uiPlayerDead.transform.Find("TimeToRespawnText").GetComponent<TMP_Text>().text = Mathf.FloorToInt(playerSpawner.timeToSpawn % 60).ToString();
    }

    void CheckFountanBroken()
    {
        if (fountain.activeInHierarchy == true) return;

        minute = Mathf.FloorToInt(GameController.instance.timeSurvival / 60);
        second = Mathf.FloorToInt(GameController.instance.timeSurvival % 60);
        timeSurvivalText.text = string.Format("Time Survival : {0:00}:{1:00}", minute, second);
        GameController.instance.PauseGame();
        uiGameOver.gameObject.SetActive(true);
    }

    void ActiveEscMenuByKey()
    {
        if (isInventoryMenuOpen == true) return;
        if (isEquipmentMenuOpen == true) return;

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isEscMenuOpen == false)
            {
                uiEsc.gameObject.SetActive(true);
                isEscMenuOpen = true;
                GameController.instance.PauseGame();
            }
            else
            {
                uiEsc.gameObject.SetActive(false);
                isEscMenuOpen = false;
                GameController.instance.ContinueGame();
            }
        }
    }

    void ActiveInventoryByKey()
    {
        if (isEscMenuOpen == true) return;
        if (isEquipmentMenuOpen == true) return;

        if (Input.GetKeyDown(KeyCode.I))
        {
            if (isInventoryMenuOpen == false)
            {
                uiInventory.gameObject.SetActive(true);
                isInventoryMenuOpen = true;
                GameController.instance.PauseGame();
            }
            else
            {
                uiInventory.gameObject.SetActive(false);
                isInventoryMenuOpen = false;
                GameController.instance.ContinueGame();
            }
        }
    }

    void CloseInventoryByKeyEsc()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isInventoryMenuOpen == true)
            {
                uiInventory.gameObject.SetActive(false);
                isInventoryMenuOpen = false;
                GameController.instance.ContinueGame();
            }
        }
    }

    void ActiveEquipmentByKey()
    {
        if (isEscMenuOpen == true) return;
        if (isInventoryMenuOpen == true) return;

        if (Input.GetKeyDown(KeyCode.E))
        {
            if (isEquipmentMenuOpen == false)
            {
                uiEquipmentWeapon.gameObject.SetActive(true);
                isEquipmentMenuOpen = true;
                GameController.instance.PauseGame();
            }
            else
            {
                uiEquipmentWeapon.gameObject.SetActive(false);
                isEquipmentMenuOpen = false;
                GameController.instance.ContinueGame();
            }
        }
    }

    void CloseEquipmentByKeyEsc()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isEquipmentMenuOpen == true)
            {
                uiEquipmentWeapon.gameObject.SetActive(false);
                isEquipmentMenuOpen = false;
                GameController.instance.ContinueGame();
            }
        }
    }

    public void CloseEscMenu()
    {
        uiEsc.gameObject.SetActive(false);
        isEscMenuOpen = false;
        GameController.instance.ContinueGame();
    }

    public void OpenEscMenu()
    {
        uiEsc.gameObject.SetActive(true);
        isEscMenuOpen = true;
        GameController.instance.PauseGame();
    }

    public void CloseInventoryMenu()
    {
        if (isInventoryMenuOpen == true)
        {
            uiInventory.gameObject.SetActive(false);
            isInventoryMenuOpen = false;
            GameController.instance.ContinueGame();
        }
    }

    public void ActiveInventoryMenu()
    {
        if (isInventoryMenuOpen == true)
        {
            uiInventory.gameObject.SetActive(false);
            isInventoryMenuOpen = false;
            GameController.instance.ContinueGame();
        }
        else
        {
            uiInventory.gameObject.SetActive(true);
            isInventoryMenuOpen = true;
            GameController.instance.PauseGame();
        }
    }

    public void ClickToBackMainMenu()
    {
        GameController.instance.ContinueGame();
        GameController.instance.GameOver();
    }
}
