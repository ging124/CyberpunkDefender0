using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class EnemyHurt : MonoBehaviour
{
    public int currentHp;
    public int maxHp = 10;
    [SerializeField]
    private Image hpBar;

    [SerializeField]
    private Material matRed;
    [SerializeField]
    private Material matDefault;
    [SerializeField]
    private SpriteRenderer sr;

    [SerializeField]
    private GameObject floatTextPrefab;

    private EnemyDead enemyDead;
    private bool isDead = false;


    void Awake()
    {
        enemyDead = gameObject.transform.parent.GetComponentInChildren<EnemyDead>();
        currentHp = maxHp;
        matDefault = sr.material;
    }

    void Update()
    {
        UpdateEnemyHpBar();
        CheckEnemyDead();
    }

    public void TakeDamage(int damage)
    {
        currentHp -= damage;
        sr.material = matRed;
        Invoke(nameof(ResetMaterial), 0.1f);
        ShowFloatingText(damage);
    }

    public void UpdateEnemyHpBar()
    {
        hpBar.fillAmount = (float)currentHp / maxHp;
    }

    void CheckEnemyDead()
    {
        if (isDead == true) return;

        if (currentHp <= 0)
        {
            enemyDead.Dead();
            isDead = true;
        }
    }

    void ResetMaterial()
    {
        sr.material = matDefault;
    }

    public void ShowFloatingText(int damage)
    {
        if (floatTextPrefab == null && currentHp <= 0) return;

        var damageText = Instantiate(floatTextPrefab, transform.position, Quaternion.identity, transform);
        damageText.GetComponent<TextMesh>().text = damage.ToString();
    }
}
