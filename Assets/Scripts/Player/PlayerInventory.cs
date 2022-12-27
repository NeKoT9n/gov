using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInventory
{
    public List<Gun> Guns { get; private set; }
    public Gun CurrentGun { get; set; }

    public PlayerInventory()
    {
        Guns = new List<Gun>(3);
    }

    public void AddGun(Gun gun)
    {
        if (Guns.Count >= 3)
        {
            SwitchGun(gun);
            return;
        }


        Guns.Add(gun);
        CurrentGun = gun;
    }

    public void SwitchGun(Gun gun)
    {
        Guns.Remove(CurrentGun);
        Guns.Add(gun);
        gun = CurrentGun;
    }

    public Gun GetGunById(int id)
    {
        if (id < 0 || id >= Guns.Count)
            return null;

        else
            return Guns[id];
    }
}
