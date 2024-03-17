using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UI_StatusDetail : MonoBehaviour
{
    private TMP_Text attackText;
    private TMP_Text hpText;
    private TMP_Text speedText;

    void Awake()
    {
        attackText = transform.Find("AttackText").GetComponent<TMP_Text>();
        hpText = transform.Find("HPText").GetComponent<TMP_Text>();
        speedText = transform.Find("SpeedText").GetComponent<TMP_Text>();
    }

    void Update()
    {
        attackText.text = "+ " + (PlayerController.instance.playerAttack.attackDamage - 25).ToString() + " ATK";
        hpText.text = "+ " + (PlayerController.instance.playerHurt.maxHp - 100).ToString() + " HP";
        speedText.text = "+ " + (PlayerController.instance.playerMovement.moveSpeed - 60).ToString() + " SPD";
    }
}
