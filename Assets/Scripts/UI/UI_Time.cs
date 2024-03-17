using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UI_Time : MonoBehaviour
{
    [SerializeField]
    private TMP_Text timeText;
    private float minute;
    private float second;

    void Awake()
    {
        timeText = transform.GetComponentInChildren<TMP_Text>();
    }

    void Update()
    {
        DisplayTime();
    }

    void DisplayTime()
    {
        minute = Mathf.FloorToInt(GameController.instance.timeSurvival / 60);
        second = Mathf.FloorToInt(GameController.instance.timeSurvival % 60);
        timeText.text = string.Format("{0:00}:{1:00}", minute, second);
    }
}
