using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EnemyFollowFountain : MonoBehaviour
{
    [SerializeField]
    private GameObject fountain;
    [SerializeField]
    private Transform enemy;

    [field: SerializeField]
    public float disLimit { get; private set; }
    [SerializeField]
    private float moveSpeed = 0.5f;
    protected float timeDelay = 0.5f;
    protected float timeSpawn = 0;
    private Animator animator;
    public bool canRun = true;
    [field: SerializeField]
    public Vector3 distance { get; private set; }

    void Awake()
    {
        enemy = gameObject.transform.parent;
        fountain = GameObject.Find("Fountain");
        animator = enemy.GetComponent<Animator>();
        distance = fountain.transform.position - enemy.position;
    }

    void Update()
    {
        if (canRun)
        {
            SetAnimationRun();
            Follow();
        }
    }

    void Follow()
    {
        if (fountain == null) return;

        FlipObject(distance);
        if (distance.magnitude >= disLimit)
        {
            Vector2 targetPoint = fountain.transform.position - distance.normalized * disLimit;
            enemy.position = Vector2.MoveTowards(enemy.position, new Vector2(targetPoint.x, enemy.position.y), moveSpeed * Time.deltaTime);
        }
    }

    void SetAnimationRun()
    {
        if (distance != Vector3.zero)
        {
            animator.SetFloat("Speed", 1);
        }
        else
        {
            animator.SetFloat("Speed", 0);
        }
    }

    public void FlipObject(Vector3 movement)
    {
        if (movement.x < 0)
        {
            enemy.rotation = Quaternion.Euler(0, -180f, 0);
        }
        else if (movement.x > 0)
        {
            enemy.rotation = Quaternion.Euler(0, 0, 0);
        }
    }
}
