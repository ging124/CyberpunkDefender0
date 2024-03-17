using UnityEngine;

public class EnemyDead : MonoBehaviour
{
    [SerializeField]
    private ParticleSystem expParticle;

    private Transform enemy;
    private Collider2D col2D;
    private Rigidbody2D rig2D;
    private Animator animator;

    private EnemyDropItem enemyDropItem;
    private EnemyFollowFountain enemyFollowFountain;
    private EnemyAttack enemyAttack;

    void Awake()
    {
        enemy = transform.parent;
        col2D = enemy.GetComponent<Collider2D>();
        rig2D = enemy.GetComponent<Rigidbody2D>();
        animator = enemy.GetComponent<Animator>();

        enemyDropItem = enemy.GetComponentInChildren<EnemyDropItem>();
        enemyFollowFountain = enemy.GetComponentInChildren<EnemyFollowFountain>();
        enemyAttack = enemy.GetComponentInChildren<EnemyAttack>();
    }

    public void Dead()
    {
        col2D.enabled = false;
        rig2D.bodyType = RigidbodyType2D.Static;
        animator.SetTrigger("isDead");
        enemyFollowFountain.enabled = false;
        enemyAttack.reloadImage.gameObject.SetActive(false);
        enemyAttack.enabled = false;
        Instantiate(expParticle, transform.position, Quaternion.identity);
        enemyDropItem.DropItem();
        Destroy(enemy.gameObject, 1f);
    }
}
