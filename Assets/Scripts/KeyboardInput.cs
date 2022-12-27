using UnityEngine;

public class KeyboardInput : MonoBehaviour
{
    [SerializeField] private Player _player;
    [SerializeField] private PlayerInventory _inventory;
    [SerializeField] private FlashLight _flashLight;
    [SerializeField] private WeaponSwitcher _weaponSwitcher;

    private Vector2 _direction;

    private void Start()
    {
        _inventory = _weaponSwitcher.Inventory;
    }

    private void Update()
    {
        _direction.x = Input.GetAxisRaw("Horizontal");
        _direction.y = Input.GetAxisRaw("Vertical");

        var gun = _inventory.CurrentGun;

        if (Input.GetMouseButton(0) && gun.IsAutomatic == true)
        {
            gun.Shoot();
        }
        else if (Input.GetMouseButtonDown(0))
        {
            gun.Shoot();
        }

        if (Input.GetKeyDown(KeyCode.F))
        {
            _flashLight.SwitchActive();
        }

        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            _weaponSwitcher.SetGun(0);
        }

        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            _weaponSwitcher.SetGun(1);
        }

        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            _weaponSwitcher.SetGun(2);
        }
    }

    private void FixedUpdate()
    {
        _player.Move(_direction);
    }

}
