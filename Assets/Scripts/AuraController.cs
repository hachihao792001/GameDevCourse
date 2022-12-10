using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AuraController : MonoBehaviour
{
    [SerializeField] Transform _player;
    [SerializeField] LayerMask _groundLayerMask;
    [SerializeField] float _distanceToGround;

    void Update()
    {
        if (Physics.Raycast(_player.position + Vector3.up * 5, Vector3.down, out RaycastHit hit, 100, _groundLayerMask))
        {
            transform.position = hit.point + hit.normal * _distanceToGround;
            transform.up = hit.normal;
        }
    }
}
