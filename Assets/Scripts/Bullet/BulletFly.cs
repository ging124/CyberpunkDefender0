using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletFly : MonoBehaviour
{
    private int bulletDamage = 15;
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
        if(col.gameObject.tag == "Enemy")
        {
            Instantiate(hitEffect, transform.position, transform.rotation, col.gameObject.transform);
            col.gameObject.GetComponentInChildren<EnemyHurt>().TakeDamage(bulletDamage);
            Destroy(gameObject);
        }
    }

    public void SetBulletDamage(int damage)
    {
        bulletDamage = damage;
    }
}
