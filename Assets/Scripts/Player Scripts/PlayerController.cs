using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    public static PlayerController instance { get; private set; }

    public GameObject player;
    public Rigidbody2D rb;
    public Animator animator;

    public PlayerFlip playerFlip;
    public PlayerMovement playerMovement;
    public PlayerEquipment playerEquipment;
    public PlayerEffect playerEffect;
    public PlayerBullet playerBullet;
    public PlayerAttack playerAttack;
    public PlayerHurt playerHurt;
    public PlayerInventory playerInventory;
    public PlayerGearEquipment playerGearEquipment;
    public PlayerLevel playerLevel;

    private void Awake()
    {
        if(PlayerController.instance != null) Debug.LogError("Only 1 PlayerController allow to exist");

        PlayerController.instance = this;

        player = GameObject.Find("Character");
        rb = player.GetComponent<Rigidbody2D>();

        animator = player.GetComponentInChildren<Animator>();
        playerMovement = player.GetComponentInChildren<PlayerMovement>();
        playerFlip = player.GetComponentInChildren<PlayerFlip>();
        playerEquipment = player.GetComponentInChildren<PlayerEquipment>();
        playerEffect = player.GetComponentInChildren<PlayerEffect>();
        playerBullet = player.GetComponentInChildren<PlayerBullet>();
        playerAttack = player.GetComponentInChildren<PlayerAttack>();
        playerHurt = player.GetComponentInChildren<PlayerHurt>();
        playerInventory = player.GetComponentInChildren<PlayerInventory>();
        playerGearEquipment = player.GetComponentInChildren<PlayerGearEquipment>();
        playerLevel = player.GetComponentInChildren<PlayerLevel>();
    }
}
