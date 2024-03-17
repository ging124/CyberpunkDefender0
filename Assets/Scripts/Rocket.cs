using UnityEngine;
using System.Collections;

public class Rocket : MonoBehaviour
{
    public Transform target;

    public float speed = 5f;
    private float rotateSpeed = 500f;

    private Rigidbody2D rb;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        Missiles();
    }

    void Missiles()
    {
        if (target != null)
        {
            Vector2 direction = (Vector2)target.position - rb.position;
            direction.Normalize();
            float rotateAmount = Vector3.Cross(direction, transform.up).z;
            rb.velocity = transform.up * speed;
            rb.angularVelocity = -rotateAmount * rotateSpeed;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Enemy"))
        {
            col.GetComponentInChildren<EnemyHurt>().TakeDamage(10);
            Destroy(gameObject);
        }
    }
}
