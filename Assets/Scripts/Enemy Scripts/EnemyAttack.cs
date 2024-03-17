using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    [SerializeField] private Animator animator;
    [SerializeField] private Transform enemy;
    [SerializeField] private EnemyFollowFountain enemyFollowFountain;
    [SerializeField] private GameObject player;
    [SerializeField] private Vector2 distancePlayer;
    [SerializeField] private float distanceToAttack = 2.2f;

    [SerializeField] public int enemyDamage = 2;
    [SerializeField] private float reloadTime = 1;
    public Transform reloadImage;
    [SerializeField] private EnemyBullet enemyBullet;
    [SerializeField] private float cooldown = 0.5f;
    private float lastAttackedAt = -9999f;
    [SerializeField] private GameObject attackPoint;
    [field: SerializeField] public int maxAmmo { get; private set; }
    [field: SerializeField] public int currentAmmo { get; private set; }
    private bool isReloading = false;
    private bool canAttack = false;

    [SerializeField] private bool isMeleAttack = false;

    void Awake()
    {
        enemy = gameObject.transform.parent;
        animator = enemy.GetComponentInChildren<Animator>();
        enemyFollowFountain = enemy.GetComponentInChildren<EnemyFollowFountain>();
        enemyBullet = enemy.GetComponentInChildren<EnemyBullet>();

        player = GameObject.Find("Character");

        reloadImage.gameObject.SetActive(false);
    }

    void Update()
    {
        CheckAttack();

        if (Time.time > lastAttackedAt + cooldown)
        {
            Attack();
            lastAttackedAt = Time.time;
        }
    }

    void Attack()
    {
        if(isMeleAttack)
        {
            MeleAttack();
        }
        else
        {
            RangedAttack();
        }
    }

    void MeleAttack()
    {

    }

    void RangedAttack()
    {
        enemyFollowFountain.canRun = false;

        if (isReloading)
        {
            return;
        }

        if (currentAmmo <= 0)
        {
            StartCoroutine(Reload());
            return;
        }

        if (canAttack)
        {
            Shooting();
        }
    }

    void Shooting()
    {
        animator.SetTrigger("isAttack");
        InstantiateEnemyBullet();
    }

    void InstantiateEnemyBullet()
    {
        currentAmmo--;
        GameObject bullet = Instantiate(enemyBullet.listBullet[0].gameObject,
                                        transform.position, Quaternion.identity);
        if (enemy.transform.rotation == Quaternion.Euler(0, 180, 0))
        {
            bullet.transform.rotation = Quaternion.Euler(0, 180, 0);
        }
        bullet.GetComponent<EnemyBulletFly>().GetBulletDamage(enemyDamage);
        bullet.transform.position = attackPoint.transform.position;
        bullet.SetActive(true);
    }

    IEnumerator Reload()
    {
        isReloading = true;
        reloadImage.gameObject.SetActive(true);
        animator.SetFloat("Speed", 0);
        yield return new WaitForSeconds(reloadTime);
        currentAmmo = maxAmmo;
        isReloading = false;
        reloadImage.gameObject.SetActive(false);
    }

    void CheckAttack()
    {
        if (player == null) return;

        distancePlayer = player.transform.position - enemy.transform.position;

        if (enemyFollowFountain.distance.magnitude < distanceToAttack || distancePlayer.magnitude < distanceToAttack)
        {
            canAttack = true;
            enemyFollowFountain.canRun = false;
        }
        else
        {
            canAttack = false;
            enemyFollowFountain.canRun = true;
        }
    }
}