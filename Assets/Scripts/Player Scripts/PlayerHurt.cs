using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PlayerHurt : MonoBehaviour
{
    public PlayerDead playerDead;

    public int maxHp;
    public int currentHp;

    [SerializeField]
    private Material matRed;
    [SerializeField]
    private Material matDefault;
    [SerializeField]
    private SpriteRenderer sr;

    [SerializeField]
    private Image hpBar;
    [SerializeField]
    private TMP_Text hpText;

    void Start()
    {
        playerDead = PlayerController.instance.player.GetComponentInChildren<PlayerDead>();
        sr = PlayerController.instance.player.GetComponentInChildren<SpriteRenderer>();
        currentHp = maxHp;
        matDefault = sr.material;
    }


    void Update()
    {
        PlayerHpBar();
        CheckPlayerDead();
    }

    public void TakeDamage(int damage)
    {
        currentHp -= damage;
        sr.material = matRed;
        Invoke(nameof(ResetMaterial), 0.1f);
    }

    void ResetMaterial()
    {
        sr.material = matDefault;
    }

    public void PlayerHpBar()
    {
        hpBar.fillAmount = (float)currentHp / maxHp;
        hpText.text = currentHp.ToString() + "/" + maxHp.ToString(); 
    }

    void CheckPlayerDead()
    {
        if (currentHp <= 0)
        {
            playerDead.Dead();
        }
    }

    public void SetMaxHp()
    {
        currentHp = maxHp;
    }
}