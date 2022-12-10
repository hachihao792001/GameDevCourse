using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThirdPersonCameraController : MonoBehaviour
{
    float _yaw, _pitch;
    [SerializeField] float _sensitivity;
    [SerializeField] Vector3 currentOffset;
    [SerializeField] float _cameraDistance;
    [SerializeField] Transform _playerPivot;
    [SerializeField] float _minPitch = -60;
    [SerializeField] float _maxPitch = 60;

    private void Start()
    {
        currentOffset = Vector3.forward * _cameraDistance;
    }
    void Update()
    {
        UpdateMouse();
    }
    private void UpdateMouse()
    {
        _yaw += Input.GetAxis("Mouse X") * _sensitivity;
        _pitch += Input.GetAxis("Mouse Y") * _sensitivity;
        ClampPitchAngle();

        currentOffset = Quaternion.AngleAxis(_yaw, Vector3.up) * (Quaternion.AngleAxis(_pitch, Vector3.right) * Vector3.forward);
        currentOffset *= _cameraDistance;

        transform.position = _playerPivot.position + currentOffset;
        transform.LookAt(_playerPivot);

    }
    void ClampPitchAngle()
    {
        float pitch = _pitch;
        while (pitch > 180)
        {
            pitch -= 360;
        }
        while (pitch < -180)
        {
            pitch += 360;
        }

        pitch = Mathf.Clamp(pitch, _minPitch, _maxPitch);
        _pitch = pitch;
    }
}
