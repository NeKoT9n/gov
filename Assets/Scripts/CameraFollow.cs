using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] private Transform _target;
    [SerializeField, Range(0, 1)] private float duretion = 0.1f;
    private Camera _mainCamera;


    private void Start()
    {
        _mainCamera = Camera.main;
    }

    private void FixedUpdate()
    {
        Vector3 offset = Vector3.Lerp(transform.position, _target.position, duretion);
        offset.z = _mainCamera.transform.position.z;
        _mainCamera.transform.position = offset;

    }
}
