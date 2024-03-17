using UnityEngine;

public class LightningFly : MonoBehaviour
{
    private int bulletDamage = 15;
    [SerializeField] private GameObject lightningEffect;
    [SerializeField] private GameObject thunderEffect;
    [SerializeField] private int moveSpeed = 5;
    [SerializeField] private float rangeAttack;
    [SerializeField] private LayerMask enemyLayer;

    void Update()
    {
        transform.Translate(Vector3.right * moveSpeed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Enemy")
        {
            Destroy(gameObject);
            Collider2D[] enemies = Physics2D.OverlapCircleAll(col.transform.position, 2, enemyLayer);
            for (int i = 0; i < enemies.Length; i++)
            {
                DealDamage(enemies[i]);
                if(i >= 1)
                {
                    float distance;
                    GameObject lightningStrike;
                    distance = enemies[i].transform.position.x - enemies[i - 1].transform.position.x;
                    lightningStrike = Instantiate(lightningEffect, enemies[i - 1].transform.position, Quaternion.identity, enemies[i - 1].transform);
                    lightningStrike.GetComponent<SpriteRenderer>().size = new Vector2(distance, 0.09f);
                }
                Instantiate(thunderEffect, enemies[i].transform.position, Quaternion.identity, enemies[i].transform);
            }
        }
    }

    public void SetBulletDamage(int damage)
    {
        bulletDamage = damage;
    }

    public void DealDamage(Collider2D col)
    {
        col.gameObject.GetComponentInChildren<EnemyHurt>().TakeDamage(bulletDamage);
    }
}
