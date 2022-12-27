using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponSwitcher : MonoBehaviour
{

    public PlayerInventory Inventory { get; private set; }

    private void Awake()
    {
        Inventory = new PlayerInventory();
        Gun[] guns = GetComponentsInChildren<Gun>();
        foreach (Gun gun in guns)
        {
            Inventory.AddGun(gun);
            gun.gameObject.SetActive(false);
        }
        Inventory.CurrentGun = Inventory.GetGunById(0);
        Inventory.CurrentGun.gameObject.SetActive(true);
    }
    public void SetGun(int id)
    {
        Gun gun = Inventory.GetGunById(id);
        if (gun == Inventory.CurrentGun || gun == null)
            return;

        Inventory.CurrentGun.gameObject.SetActive(false);
        gun.gameObject.SetActive(true);
        Inventory.CurrentGun = gun;
        
    }
}
