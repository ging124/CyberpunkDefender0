using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Cinemachine.DocumentationSortingAttribute;
using UnityEngine.UI;
using TMPro;

public class PlayerLevel : MonoBehaviour
{
    [field: SerializeField]
    public int playerLevel { get; private set; } = 1;
    public int playerCurrentExp { get; private set; }
    public int playerMaxExp { get; private set; }

    [SerializeField]
    private Image expPoint;
    [SerializeField] 
    private TMP_Text expText;
    [SerializeField]
    private TMP_Text levelText;

    void Awake()
    {
        expPoint = GameObject.Find("Exp Point").GetComponent<Image>();
        levelText = GameObject.Find("Level Text").GetComponent<TMP_Text>();
        playerCurrentExp = 0;
        playerMaxExp = (int)(0.4f * Mathf.Pow((float)playerLevel, 2f) + 0.8 * Mathf.Pow((float)playerLevel, 2f) + 2 * playerLevel);
    }

    void Start()
    {
        UpdateExpUI();
    }

    public void ExpGain(int exp)
    {
        playerCurrentExp += exp;
        if (playerCurrentExp >= playerMaxExp)
        {
            LevelUp();
        }
        UpdateExpUI();
    }

    public void UpdateExpUI()
    {
        expPoint.fillAmount = (float)playerCurrentExp / playerMaxExp;
        expText.text = playerCurrentExp.ToString() + "/" + playerMaxExp.ToString();
        levelText.text = "Lv : " + playerLevel.ToString();
    }

    void LevelUp()
    {
        playerLevel++;
        levelText.text = "Lv : " + playerLevel.ToString(); 
        //PlayerController.instance.playerAttack.attackDamage += 1;
        playerCurrentExp = 0;
        playerMaxExp = (int)(0.4f * Mathf.Pow((float)playerLevel, 2f) + 0.8 * Mathf.Pow((float)playerLevel, 2f) + 2 * playerLevel);
        /*pointAbility += 3;
        pointSkill += 1;
        AbilityPoint.instance.pointAbility.text = pointAbility.ToString();
        SkillPoint.instance.pointSkill.text = pointSkill.ToString();*/
    }
}
