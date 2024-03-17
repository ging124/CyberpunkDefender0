using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class EnemyLevel : MonoBehaviour
{
    [field: SerializeField] public int enemyLevel { get; private set; } = 1;
    [SerializeField] private GameObject levelText;

    [SerializeField] private EnemyAttack enemyAttack;
    [SerializeField] private EnemyHurt enemyHurt;
    [SerializeField] private Transform enemy;


    void Awake()
    {
        enemy = transform.parent;
        enemyAttack = transform.parent.GetComponentInChildren<EnemyAttack>();
        enemyHurt = transform.parent.GetComponentInChildren<EnemyHurt>();
    }

    void Start()
    {
        enemyLevel += (int)(GameController.instance.timeSurvival / 60);
        levelText.GetComponent<TMP_Text>().text = "Lv : " + enemyLevel.ToString(); 
        enemyAttack.enemyDamage = enemyLevel * 2; 
        enemyHurt.maxHp = enemyLevel*50;
        enemyHurt.currentHp = enemyHurt.maxHp;
    }

    void Update()
    {
        LevelTextFlip();
    }

    void LevelTextFlip()
    {
        if(enemy.rotation == Quaternion.Euler(0, 180f, 0))
        {
            levelText.GetComponent<RectTransform>().localRotation = Quaternion.Euler(0, 180, 0);
        }
    }
}
