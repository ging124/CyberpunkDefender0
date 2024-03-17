using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UI_Money : MonoBehaviour
{
    [SerializeField] private TMP_Text moneyText;

    void Start()
    {
        moneyText = GetComponent<TMP_Text>();
    }

    // Update is called once per frame
    void Update()
    {
        moneyText.text = PlayerController.instance.playerInventory.money.ToString() + "$";
    }
}
