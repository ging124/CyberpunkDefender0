using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using static UnityEngine.InputSystem.LowLevel.InputStateHistory;
using static UnityEngine.Rendering.DebugUI;

public class UI_Equipment : MonoBehaviour
{
    [SerializeField]
    private GameObject uiKnife;
    [SerializeField]
    private Image iconKnife;

    [SerializeField]
    private GameObject uiPistol;
    [SerializeField]
    private Image iconPistol;

    [SerializeField]
    private GameObject uiRifle;
    [SerializeField]
    private Image iconRifle;

    [SerializeField]
    public GameObject uiRifleBullet;
    [SerializeField]
    private GameObject uiPistolBullet;
    [SerializeField]
    private Color colorActive;
    [SerializeField]
    private Color colorDeactive;

    [SerializeField]
    private TMP_Text rifleAmmoText;
    public Image rifleReloadImage;
    public GameObject rifleBulletImage;

    [SerializeField]
    private TMP_Text pistolAmmoText;
    public Image pistolReloadImage;
    public GameObject pistolBulletImage;

    void Update()
    {
        SwapWeaponUI();
    }

    void SwapWeaponUI()
    {
        if (PlayerController.instance.playerEquipment.isMeleAttack)
        {
            uiRifleBullet.SetActive(false);
            uiPistolBullet.SetActive(false);
            iconKnife.color = colorActive;
            iconPistol.color = colorDeactive;
            iconRifle.color = colorDeactive;
            uiKnife.GetComponent<RectTransform>().localScale = new Vector3(0.98f, 1, 1);
            uiPistol.GetComponent<RectTransform>().localScale = new Vector3(1f, 1, 1);
            uiRifle.GetComponent<RectTransform>().localScale = new Vector3(1f, 1, 1);
        }
        else if (PlayerController.instance.playerEquipment.isRifleShooting)
        {
            if (!PlayerController.instance.playerAttack.isRifleReloading)
            {
                rifleReloadImage.gameObject.SetActive(false);
            }

            uiRifleBullet.SetActive(true);
            uiPistolBullet.SetActive(false);
            ShowRifleBulletAmmo(PlayerController.instance.playerAttack.rifleCurrentAmmo, PlayerController.instance.playerAttack.rifleCurrentMag);
            iconKnife.color = colorDeactive;
            iconPistol.color = colorDeactive;
            iconRifle.color = colorActive;
            uiKnife.GetComponent<RectTransform>().localScale = new Vector3(1f, 1, 1);
            uiPistol.GetComponent<RectTransform>().localScale = new Vector3(1f, 1, 1);
            uiRifle.GetComponent<RectTransform>().localScale = new Vector3(0.98f, 1, 1);
        }
        else
        {
            if(!PlayerController.instance.playerAttack.isPistolReloading)
            {
                pistolReloadImage.gameObject.SetActive(false);
            }


            uiRifleBullet.SetActive(false);
            uiPistolBullet.SetActive(true);
            ShowPistolBulletAmmo(PlayerController.instance.playerAttack.pistolCurrentAmmo, PlayerController.instance.playerAttack.pistolCurrentMag);
            iconKnife.color = colorDeactive;
            iconPistol.color = colorActive;
            iconRifle.color = colorDeactive;
            uiKnife.GetComponent<RectTransform>().localScale = new Vector3(1f, 1, 1);
            uiPistol.GetComponent<RectTransform>().localScale = new Vector3(0.98f, 1, 1);
            uiRifle.GetComponent<RectTransform>().localScale = new Vector3(1f, 1, 1);
        }
    }

    void ShowRifleBulletAmmo(int ammo, int mag)
    {
        rifleAmmoText.text = string.Format("{0:00} / {1:00}", ammo, mag);
    }

    void ShowPistolBulletAmmo(int ammo, int mag)
    {
        pistolAmmoText.text = string.Format("{0:00} / {1:00}", ammo, mag);
    }
}
