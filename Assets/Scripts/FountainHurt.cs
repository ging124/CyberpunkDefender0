using UnityEngine;
using UnityEngine.UI;

public class FoutainHurt : MonoBehaviour
{
    [SerializeField]
    private int maxHp;
    [SerializeField]
    private int currentHp;

    [SerializeField]
    private Material matRed;
    [SerializeField]
    private Material matDefault;
    [SerializeField]
    private SpriteRenderer sr;

    [SerializeField]
    private Image hpBar;

    void Start()
    {
        sr = transform.parent.GetComponentInChildren<SpriteRenderer>();
        currentHp = maxHp;
        matDefault = sr.material;
    }

    void Update()
    {
        FountainHpBar();
        CheckFountainBroken();
    }


    public void TakeDamage(int damage)
    {
        currentHp -= damage;
        sr.material = matRed;
        Invoke(nameof(ResetMaterial), 0.1f);
    }

    void ResetMaterial()
    {
        sr.material = matDefault;
    }

    public void FountainHpBar()
    {
        hpBar.fillAmount = (float)currentHp / maxHp;
    }
    
    void CheckFountainBroken()
    {
        if (currentHp <= 0)
        {
            transform.parent.gameObject.SetActive(false);
        }
    }
}
