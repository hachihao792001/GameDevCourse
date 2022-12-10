using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowScript : MonoBehaviour
{
    [SerializeField] Transform _target;
    [SerializeField] Vector3 _offset;
    [SerializeField] bool[] _ignorePos = new bool[3];
    [SerializeField] bool[] _ignoreRot = new bool[3];

    private void Update()
    {
        Vector3 oldPos = transform.position;
        Vector3 newPos = _target.position + _offset;
        transform.position = new Vector3(
            _ignorePos[0] ? oldPos.x : newPos.x,
            _ignorePos[1] ? oldPos.y : newPos.y,
            _ignorePos[2] ? oldPos.z : newPos.z);

        Vector3 oldEuler = transform.eulerAngles;
        Vector3 newEuler = _target.eulerAngles;
        transform.eulerAngles = new Vector3(
            _ignoreRot[0] ? oldEuler.x : newEuler.x,
            _ignoreRot[1] ? oldEuler.y : newEuler.y,
            _ignoreRot[2] ? oldEuler.z : newEuler.z);
    }
}
