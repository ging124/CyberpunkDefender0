using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Money : MonoBehaviour
{
    [SerializeField] private float money;

    private void OnTriggerEnter2D(Collider2D col)
    {
        if(col.tag == "Player")
        {
            PlayerController.instance.playerInventory.GetMoney(money);
            Destroy(gameObject);
        }
    }

    public void SetMoney(float money)
    {
        this.money = money;
    }
}
