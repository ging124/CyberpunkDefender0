using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerEquipment : MonoBehaviour
{
    public bool isMeleAttack { get; private set; } = true;
    public bool isRifleShooting { get; private set; } = true;

    [field: SerializeField]
    public bool isLightningShooting { get; private set; } = false;
    [field: SerializeField]
    public bool isLazerShooting { get; private set; } = false;
    [field: SerializeField]
    public bool isRocketShooting { get; private set; } = false;

    void Start()
    {
        ChangeToKnife();
    }

    void Update()
    {
        ChangeWeapon();
    }

    void ChangeWeapon()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            ChangeToRifle(); // Rifle
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            ChangeToPistol(); // Pistol
        }
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            ChangeToKnife(); // Knife
        }
    }

    void ChangeToRifle()
    {
        isMeleAttack = false;
        isRifleShooting = true;

        StopCoroutine(PlayerController.instance.playerAttack.PistolReload());

        ChangeRifleWeapon();
        PlayerController.instance.animator.SetLayerWeight(0, 0);
        PlayerController.instance.animator.SetLayerWeight(1, 0);
    }

    void ChangeToPistol()
    {
        isMeleAttack = false;
        isRifleShooting = false;

        StopCoroutine(PlayerController.instance.playerAttack.RifleReload());


        PlayerController.instance.animator.SetLayerWeight(1, 1);
        PlayerController.instance.animator.SetLayerWeight(0, 0);
        DeactiveRifleWeapon();
    }

    void ChangeToKnife()
    {
        isMeleAttack = true;

        StopCoroutine(PlayerController.instance.playerAttack.RifleReload());
        StopCoroutine(PlayerController.instance.playerAttack.PistolReload());

        PlayerController.instance.animator.SetLayerWeight(0, 1);
        PlayerController.instance.animator.SetLayerWeight(1, 0);
        DeactiveRifleWeapon();
    }

    void ChangeRifleWeapon()
    {
        if(isLightningShooting == true)
        {
            PlayerController.instance.animator.SetLayerWeight(3, 1);
        }
        else if (isLazerShooting == true)
        {
            PlayerController.instance.animator.SetLayerWeight(4, 1);
        }
        else if (isRocketShooting == true)
        {
            PlayerController.instance.animator.SetLayerWeight(5, 1);
        }
        else
        {
            PlayerController.instance.animator.SetLayerWeight(2, 1);
        }
    }

    void DeactiveRifleWeapon()
    {
        PlayerController.instance.animator.SetLayerWeight(2, 0);
        PlayerController.instance.animator.SetLayerWeight(3, 0);
        PlayerController.instance.animator.SetLayerWeight(4, 0);
        PlayerController.instance.animator.SetLayerWeight(5, 0);
    }
}
