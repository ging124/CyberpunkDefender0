using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDropItem : MonoBehaviour
{
    [SerializeField]
    private float dropRate = 0.01f;
    [SerializeField]
    private List<ItemWorldSpawner> itemListDrop;
    [SerializeField]
    private GameObject moneyPrefab;
    [SerializeField]
    private float money;

    [SerializeField]
    private EnemyLevel enemyLevel;

    void Awake()
    {
        enemyLevel = transform.parent.GetComponentInChildren<EnemyLevel>();
    }

    public void DropItem()
    {
        DropMoney();
        foreach (ItemWorldSpawner itemDrop in itemListDrop)
        {
            if (enemyLevel.enemyLevel >= itemDrop.item.reqLevel && Random.Range(0f, 1f) < dropRate)
            {
                Instantiate(itemDrop.gameObject, new Vector2(transform.position.x + Random.Range(-0.1f, 0.1f), transform.position.y ), Quaternion.identity);
                return;
            }
        }
    }

    public void DropMoney()
    {
        money = enemyLevel.enemyLevel * 100;
        GameObject moneyWorld = Instantiate(moneyPrefab, transform.position, Quaternion.identity);
        moneyWorld.GetComponent<Money>().SetMoney(money);
    }
}
