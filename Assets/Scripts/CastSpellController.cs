using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.ThirdPerson;
public class CastSpellController : MonoBehaviour
{
    [SerializeField] ThirdPersonUserControl userControl;
    [SerializeField] Animator animator;
    [SerializeField] Collider _collider;
    [SerializeField] Rigidbody _rb;
    public bool IsPlayingCastSpellAnim;

    [SerializeField] GameObject _firePillarPrefab;
    [SerializeField] float _firePillarSpawnDistance;
    [SerializeField] GameObject _fireBallPrefab;
    [SerializeField] Transform _fireBallSpawnPos;

    void Update()
    {
        if (IsPlayingCastSpellAnim) return;
        if (Input.GetKeyDown(KeyCode.E))
        {
            animator.SetTrigger("CastFirePillar");
            if (!userControl.IsMoving)
            {
                animator.SetTrigger("CastFirePillarLeg");
                _collider.enabled = false;
                _rb.isKinematic = true;
                animator.applyRootMotion = true;
            }
            IsPlayingCastSpellAnim = true;
        }
        if (Input.GetKeyDown(KeyCode.Q))
        {
            animator.SetTrigger("CastFireBall");
            if (!userControl.IsMoving)
            {
                animator.SetTrigger("CastFireBallLeg");
                _collider.enabled = false;
                _rb.isKinematic = true;
                animator.applyRootMotion = true;
            }
            IsPlayingCastSpellAnim = true;
        }
    }

    public void OnCastFirePillar()
    {
        Instantiate(_firePillarPrefab, transform.position + transform.forward * _firePillarSpawnDistance, Quaternion.identity);
    }
    public void OnCastFireBall()
    {
        Instantiate(_fireBallPrefab, _fireBallSpawnPos.position, Quaternion.identity).transform.forward = transform.forward;
    }
    public void CastSpellDone()
    {
        IsPlayingCastSpellAnim = false;
        _collider.enabled = true;
        _rb.isKinematic = false; animator.applyRootMotion = false;
    }
}
