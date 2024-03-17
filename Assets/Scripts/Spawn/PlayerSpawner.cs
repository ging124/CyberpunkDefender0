using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerSpawner : MonoBehaviour
{
    private GameObject player;
    [SerializeField]
    private GameObject playerPrefab;

    [field: SerializeField]
    public float timeToSpawn{get; private set; } = 6;

    void Start()
    {
        player = GameObject.Find("Character");
    }

    void Update()
    {
        SpawnPlayer();
    }

    void SpawnPlayer()
    {
        if (player.activeInHierarchy == true) return;

        timeToSpawn -= Time.deltaTime;
        if (timeToSpawn >= 0) return;

        player.SetActive(true);
        player.transform.position = transform.position;
        PlayerController.instance.playerHurt.SetMaxHp();
        PlayerController.instance.playerAttack.enabled = true;
        PlayerController.instance.playerHurt.enabled = true;
        PlayerController.instance.playerMovement.enabled = true;
        timeToSpawn = 6;
    }
}
