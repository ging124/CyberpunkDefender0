using System.Collections;
using System.Net.Sockets;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    public int attackDamage;
    [SerializeField]
    private float meleAttackRange;
    [SerializeField]
    private GameObject meleAttackPoint;
    [SerializeField]
    private GameObject meleHitEffect;

    public int rifleAttackDamage;
    [SerializeField]
    private GameObject rifleAttackPoint;
    [field: SerializeField]
    public int rifleMaxAmmo { get; private set; }
    public int rifleCurrentAmmo { get; private set; }
    [SerializeField]
    private int rifleMaxMag;
    public int rifleCurrentMag { get; private set; }

    public bool isRifleReloading = false;
    public float rifleReloadTime;

    public int pistolAttackDamage;
    [SerializeField]
    private GameObject pistolAttackPoint;
    [field: SerializeField]
    public int pistolMaxAmmo { get; private set; }
    public int pistolCurrentAmmo { get; private set; }
    [SerializeField]
    private int pistolMaxMag;
    public int pistolCurrentMag { get; private set; }
    public bool isPistolReloading = false;
    public float pistolReloadTime;

    [SerializeField]
    private GameObject lightningAttackPoint;

    [SerializeField] 
    private GameObject lazerHitEffect;


    [SerializeField]
    private float meleCooldownAttack = 0.4f;
    [SerializeField]
    private float rangedCooldownAttack = 0.2f;
    [SerializeField]
    private LayerMask enemyLayer;
    private float lastAttackedAt = -9999f;

    void Awake()
    {
        rifleCurrentMag = rifleMaxMag;
        rifleCurrentAmmo = rifleMaxAmmo;

        pistolCurrentMag = pistolMaxMag;
        pistolCurrentAmmo = pistolMaxAmmo;
    }

    void Update()
    {
        Attack();
    }

    void Attack()
    {
        if (PlayerController.instance.playerEquipment.isMeleAttack)
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
        if (Time.time > lastAttackedAt + meleCooldownAttack)
        {
            if(Input.GetKey(KeyCode.J))
            {
                RunAttackAnimation();
                Collider2D[] hitEnemy = Physics2D.OverlapCircleAll(meleAttackPoint.transform.position, meleAttackRange, enemyLayer);
                foreach (Collider2D enemy in hitEnemy)
                {
                    enemy.GetComponentInChildren<EnemyHurt>().TakeDamage(attackDamage);
                    if (PlayerController.instance.player.transform.rotation == Quaternion.Euler(0, 180, 0))
                    {
                        Instantiate(meleHitEffect, enemy.gameObject.transform.position, Quaternion.Euler(0, 180, 0), enemy.gameObject.transform);
                    }
                    else
                    {
                        Instantiate(meleHitEffect, enemy.gameObject.transform.position, Quaternion.identity, enemy.gameObject.transform);
                    }
                }
                lastAttackedAt = Time.time;
            }
        }
    }

    void RangedAttack()
    {
        if (PlayerController.instance.playerEquipment.isRifleShooting)
        {
            RifleShooting();
        }
        else
        {
            PistolShooting();
        }
    }

    void RifleShooting()
    {
        if (isRifleReloading || rifleCurrentMag <= 0 && rifleCurrentAmmo <= 0)
        {
            return;
        }

        if (rifleCurrentAmmo <= 0)
        {
            StartCoroutine(RifleReload());
            return;
        }

        if (Time.time > lastAttackedAt + rangedCooldownAttack && Input.GetKey(KeyCode.J))
        {
            InstantiateRifleBullet();
            lastAttackedAt = Time.time;
        }
    }

    void PistolShooting()
    {
        if (isPistolReloading || pistolCurrentMag <= 0 && pistolCurrentAmmo <= 0)
        {
            return;
        }

        if (pistolCurrentAmmo <= 0)
        {
            StartCoroutine(PistolReload());
            return;
        }

        if (Time.time > lastAttackedAt + rangedCooldownAttack && Input.GetKey(KeyCode.J))
        {
            PlayerController.instance.playerEffect.listEffect[1].gameObject.SetActive(true);
            InstantiatePistolBullet();
            lastAttackedAt = Time.time;
        }
    }

    public IEnumerator RifleReload()
    {
        isRifleReloading = true;
        UI_Controller.instance.uiEquipment.rifleBulletImage.SetActive(false);
        UI_Controller.instance.uiEquipment.rifleReloadImage.gameObject.SetActive(true);
        yield return new WaitForSeconds(rifleReloadTime);
        rifleCurrentMag--;
        UI_Controller.instance.uiEquipment.rifleReloadImage.gameObject.SetActive(false);
        UI_Controller.instance.uiEquipment.rifleBulletImage.SetActive(true);
        rifleCurrentAmmo = rifleMaxAmmo;
        isRifleReloading = false;
    }

    public IEnumerator PistolReload()
    {
        isPistolReloading = true;
        UI_Controller.instance.uiEquipment.pistolBulletImage.SetActive(false);
        UI_Controller.instance.uiEquipment.pistolReloadImage.gameObject.SetActive(true);
        yield return new WaitForSeconds(pistolReloadTime);
        pistolCurrentMag--;
        UI_Controller.instance.uiEquipment.pistolReloadImage.gameObject.SetActive(false);
        UI_Controller.instance.uiEquipment.pistolBulletImage.SetActive(true);
        pistolCurrentAmmo = pistolMaxAmmo;
        isPistolReloading = false;
    }

    void InstantiateRifleBullet()
    {
        if(PlayerController.instance.playerEquipment.isLightningShooting == true)
        {
            InstanceLightningBullet();
        }
        else if(PlayerController.instance.playerEquipment.isLazerShooting == true)
        {
            InstanceLazerBullet();
        }
        else if(PlayerController.instance.playerEquipment.isRocketShooting == true)
        {
            InstanceRocketBullet();
        }
        else
        {
            PlayerController.instance.playerEffect.listEffect[0].gameObject.SetActive(true);
            InstanceNormalBullet();
        }
    }

    void InstanceNormalBullet()
    {
        rifleCurrentAmmo--;
        GameObject bullet = Instantiate(PlayerController.instance.playerBullet.listBullet[0].gameObject,
                                        transform.position,
                                        Quaternion.identity);
        bullet.GetComponent<BulletFly>().SetBulletDamage(rifleAttackDamage);
        if (PlayerController.instance.player.transform.rotation == Quaternion.Euler(0, 180, 0))
        {
            bullet.transform.rotation = Quaternion.Euler(0, -180, 0);
        }
        bullet.transform.position = rifleAttackPoint.transform.position;
        bullet.SetActive(true);
    }

    void InstanceLightningBullet()
    {
        rifleCurrentAmmo--;
        GameObject bullet = Instantiate(PlayerController.instance.playerBullet.listBullet[2].gameObject,
                                        transform.position,
                                        Quaternion.identity);
        bullet.GetComponent<LightningFly>().SetBulletDamage(rifleAttackDamage);
        if (PlayerController.instance.player.transform.rotation == Quaternion.Euler(0, 180, 0))
        {
            bullet.transform.rotation = Quaternion.Euler(0, -180, 0);
        }
        bullet.transform.position = rifleAttackPoint.transform.position;
        bullet.SetActive(true);
    }

    void InstanceLazerBullet()
    {
        RaycastHit2D hit = Physics2D.Raycast(rifleAttackPoint.transform.position, rifleAttackPoint.transform.right, 3, enemyLayer);
        rifleCurrentAmmo--;
        if (hit)
        {
            EnemyHurt enemy = hit.transform.GetComponentInChildren<EnemyHurt>();
            if (enemy != null)
            {
                Instantiate(lazerHitEffect, enemy.transform.position, Quaternion.identity, enemy.transform);
                enemy.TakeDamage(10);
                GameObject bullet = Instantiate(PlayerController.instance.playerBullet.listBullet[3].gameObject,
                                            lightningAttackPoint.transform.position,
                                            Quaternion.identity, transform);
                if (PlayerController.instance.player.transform.rotation == Quaternion.Euler(0, 180, 0))
                {
                    bullet.transform.rotation = Quaternion.Euler(0, -180, 0);
                }
                bullet.GetComponent<SpriteRenderer>().size = new Vector2(hit.distance, 0.09f);
                bullet.SetActive(true);
            }
        }
        else
        {
            GameObject bullet = Instantiate(PlayerController.instance.playerBullet.listBullet[3].gameObject,
                                            lightningAttackPoint.transform.position,
                                            Quaternion.identity, transform);
            if (PlayerController.instance.player.transform.rotation == Quaternion.Euler(0, 180, 0))
            {
                bullet.transform.rotation = Quaternion.Euler(0, -180, 0);
            }
            bullet.GetComponent<SpriteRenderer>().size = new Vector2(3f, 0.09f);
            bullet.SetActive(true);
        }
    }

    void InstanceRocketBullet()
    {
        RaycastHit2D hit = Physics2D.Raycast(rifleAttackPoint.transform.position, rifleAttackPoint.transform.right, 3, enemyLayer);
        if (hit)
        {
            EnemyHurt enemy = hit.transform.GetComponentInChildren<EnemyHurt>();
            if (enemy != null)
            {
                rifleCurrentAmmo--;
                //enemy.TakeDamage(10);
                GameObject rocket = Instantiate(PlayerController.instance.playerBullet.listBullet[4].gameObject,
                                            lightningAttackPoint.transform.position,
                                            Quaternion.identity);
                rocket.GetComponent<Rocket>().target = enemy.transform;
                if (PlayerController.instance.player.transform.rotation == Quaternion.Euler(0, 180, 0))
                {
                    rocket.transform.rotation = Quaternion.Euler(0, -180, 0);
                }
                rocket.SetActive(true);
            }
        }
    }

    void InstantiatePistolBullet()
    {
        pistolCurrentAmmo--;
        GameObject bullet = Instantiate(PlayerController.instance.playerBullet.listBullet[1].gameObject,
                                        transform.position,
                                        Quaternion.identity);
        bullet.GetComponent<BulletFly>().SetBulletDamage(pistolAttackDamage);
        if (PlayerController.instance.player.transform.rotation == Quaternion.Euler(0, 180, 0))
        {
            bullet.transform.rotation = Quaternion.Euler(0, 180, 0);
        }
        bullet.transform.position = pistolAttackPoint.transform.position;
        bullet.SetActive(true);
    }

    void RunAttackAnimation()
    {
        if (Mathf.Abs(PlayerController.instance.playerMovement.movement) > 0)
        {
            PlayerController.instance.animator.SetTrigger("isRunningAttack");
        }
        else
        {
            PlayerController.instance.animator.SetTrigger("isAttack");
        }
    }
    
    void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(meleAttackPoint.transform.position, meleAttackRange);
    }
}