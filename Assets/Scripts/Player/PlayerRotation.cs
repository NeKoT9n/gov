using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerRotation : MonoBehaviour
{
    private Camera _main;
    private Rigidbody2D _rigidbody;
    private Vector2 mousePosition;

    private void Start()
    {
        _main = Camera.main;
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        mousePosition = _main.ScreenToWorldPoint(Input.mousePosition);
    }

    private void FixedUpdate()
    {
        Vector2 lookDirection = mousePosition - _rigidbody.position;
        float angle = Mathf.Atan2(lookDirection.y, lookDirection.x) * Mathf.Rad2Deg;
        _rigidbody.rotation = angle;
    }
}
