using UnityEngine;

public class FlashLight : MonoBehaviour
{
    private bool IsActive = false;

    private void Start()
    {
        gameObject.SetActive(IsActive);
    }

    public void SwitchActive()
    {
        IsActive = !IsActive;
        gameObject.SetActive(IsActive);
    }
}
