using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBulletFly : MonoBehaviour
{
    [SerializeField]
    private int bulletDamage;
    public GameObject hitEffect;
    [SerializeField]
    private int moveSpeed = 5;
    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        transform.Translate(Vector3.right * moveSpeed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Player")
        {
            Instantiate(hitEffect, transform.position, transform.rotation);
            col.gameObject.GetComponentInChildren<PlayerHurt>().TakeDamage(bulletDamage);
            Destroy(gameObject);
        }

        if (col.gameObject.tag == "Fountain")
        {
            Instantiate(hitEffect, transform.position, transform.rotation);
            col.gameObject.GetComponentInChildren<FoutainHurt>().TakeDamage(bulletDamage);
            Destroy(gameObject);
        }
    }

    public void GetBulletDamage(int damage)
    {
        this.bulletDamage = damage;
    }
}
